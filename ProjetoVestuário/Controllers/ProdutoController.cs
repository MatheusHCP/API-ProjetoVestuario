using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repositorio;
using Entidades;
using ProjetoVestuário.Model;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace ProjetoVestuário.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public retorno<produtoModel> GetProduto (int id)
        {
            retorno<produtoModel> ret = new retorno<produtoModel>();
            try
            {
                ProdutoRepositorio rep = new ProdutoRepositorio();
                Produto pro = rep.get(id);

                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                ret.resultado = mapper.Map<produtoModel>(pro);

                if (pro == null)
                {
                    ret.status = false;
                    ret.mensagem = "Produto não localizado (:/), verifique a escrita.";
                }
                else
                {
                    ret.status = true;
                    ret.mensagem = "Produto localizado!";
                }
                return ret;
            }
            catch (Exception ex)
            {
                ret.erro = "Vish... Ocorreu um erro, dados técnicos: " + ex;
                ret.status = false;
                return ret;
            }
        }

        [Authorize]
        [HttpPost]
        public retorno<produtoModel> InserirProduto(produtoModel model)
        {
            retorno<produtoModel> ret = new retorno<produtoModel>();
            try
            {
                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                Produto pro = mapper.Map<Produto>(model);
                ProdutoRepositorio rep = new ProdutoRepositorio();
                rep.add(pro);
                model.id = pro.id;
                ret.status = true;
                ret.resultado = model;
                ret.mensagem = "Produto cadastrado com sucesso!";

            }
            catch (Exception ex)
            {
                ret.status = false;
                ret.erro = "Erro ao cadastrar novo produto (:/), verifique os dados técnicos: " + ex;
                throw;
            }

            return ret;
        }

        [Authorize]
        [HttpDelete]
        public retorno<produtoModel> apagarProduto(int id)
        {
            retorno<produtoModel> ret = new retorno<produtoModel>();
            try
            {
                ProdutoRepositorio rep = new ProdutoRepositorio();
                Produto pro = rep.get(id);
                if (pro == null)
                {
                    ret.status = false;
                    ret.erro = "Não foi possível localizar o produto para efetuar o delete.";
                }
                else
                {
                    rep.delete(pro);
                    ret.status = true;
                    ret.mensagem = "Produto localizado e apagado com sucesso!";
                    var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                    ret.resultado = mapper.Map<produtoModel>(pro);
                }
            }
            catch (Exception ex)
            {
                ret.status = false;
                ret.erro = "Erro ao deletar produto, verifique os dados técnicos: " + ex;
                throw;
            }

            return ret;
        }

        [Authorize]
        [HttpPut]
        public retorno<produtoModel> alterarProduto (produtoModel model)
        {
            retorno<produtoModel> ret = new retorno<produtoModel>();

            try
            {
                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                Produto pro = mapper.Map<Produto>(model);
                ProdutoRepositorio rep = new ProdutoRepositorio();
                rep.edit(pro);
                model.id = pro.id;
                ret.status = true;
                ret.resultado = model;
                ret.mensagem = "Produto alterado com sucesso!";
            }
            catch (Exception ex)
            {
                ret.status = false;
                ret.erro = "Erro ao alterar produto, verifique os dados técnicos: " + ex;
            }
            return ret;
        }
        

        [HttpGet]
        [Route("allProdutos")]
        public retorno<List<produtoModel>> allProdutos (string descricao)
        {
            retorno<List<produtoModel>> lista = new retorno<List<produtoModel>>();
            try
            {
                if (descricao != null)
                {
                    ProdutoRepositorio rep = new ProdutoRepositorio();
                    List<Produto> listaProd = rep.getAllDescricao(descricao); // Busca de produtos pela descrição.
                    lista.status = true;
                    var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                    lista.resultado = mapper.Map<List<produtoModel>>(listaProd);
                    if(listaProd.Count == 0)
                    {
                        lista.mensagem = "Nenhum produto encontrado.";
                    }
                    else
                    {
                        lista.mensagem = "Produto localizado com sucesso!";
                    }
                   
                }
                else
                {
                    ProdutoRepositorio rep = new ProdutoRepositorio();
                    List<Produto> listaProd = rep.getAll(); // Busca total em caso de não ter informado nada na descrição.
                    lista.status = true;
                    var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                    lista.resultado = mapper.Map<List<produtoModel>>(listaProd);
                    lista.mensagem = "Lista de todos produtos cadastrados.";
                }
            }
            catch (Exception ex)
            {
                lista.status = false;
                lista.erro = "Ocorreu um erro na busca de produtos, verifique os dados técnicos: " + ex;
            }

            return lista;
        }
    }
}
