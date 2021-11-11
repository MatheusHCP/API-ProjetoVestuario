using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entidades;
using Repositorio;
using ProjetoVestuário.Model;
using Microsoft.AspNetCore.Authorization;

namespace ProjetoVestuário.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        [HttpGet]
        public retorno<produtoCategoriaModel> getCategoria(int id)
        {
            retorno<produtoCategoriaModel> ret = new retorno<produtoCategoriaModel>();
            try
            {
                CategoriaRepositorio rep = new CategoriaRepositorio();
                produtoCategoria pro = rep.get(id);

                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                ret.resultado = mapper.Map<produtoCategoriaModel>(pro);

                if (pro == null)
                {
                    ret.status = false;
                    ret.mensagem = "Categoria não localizada (:/), verifique a escrita.";
                }
                else
                {
                    ret.status = true;
                    ret.mensagem = "Categoria localizada!";
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

        [HttpPost]
        [Authorize]
        public retorno<produtoCategoriaModel> inserirCategoria(produtoCategoriaModel model)
        {
            retorno<produtoCategoriaModel> ret = new retorno<produtoCategoriaModel>();
            try
            {
                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                produtoCategoria pro = mapper.Map<produtoCategoria>(model);
                CategoriaRepositorio rep = new CategoriaRepositorio();
                rep.add(pro);
                model.id = pro.id;
                ret.status = true;
                ret.resultado = model;
                ret.mensagem = "Categoria cadastrada com sucesso!";

            }
            catch (Exception ex)
            {
                ret.status = false;
                ret.erro = "Erro ao cadastrar nova categoria (:/), verifique os dados técnicos: " + ex;
                throw;
            }

            return ret;
        }

        [Authorize]
        [HttpDelete]
        public retorno<produtoCategoriaModel> apagarCategoria(int id)
        {
            retorno<produtoCategoriaModel> ret = new retorno<produtoCategoriaModel>();
            try
            {
                CategoriaRepositorio rep = new CategoriaRepositorio();
                produtoCategoria pro = rep.get(id);
                if (pro == null)
                {
                    ret.status = false;
                    ret.erro = "Não foi possível localizar a categoria para efetuar o delete.";
                }
                else
                {
                    rep.delete(pro);
                    ret.status = true;
                    ret.mensagem = "Categoria localizada e apagada com sucesso!";
                    var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                    ret.resultado = mapper.Map<produtoCategoriaModel>(pro);
                }
            }
            catch (Exception ex)
            {
                ret.status = false;
                ret.erro = "Erro ao deletar categoria, verifique os dados técnicos: " + ex;
                throw;
            }

            return ret;
        }

        [Authorize]
        [HttpPut]
        public retorno<produtoCategoriaModel> alterarCategoria(produtoCategoriaModel model)
        {
            retorno<produtoCategoriaModel> ret = new retorno<produtoCategoriaModel>();

            try
            {
                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                produtoCategoria pro = mapper.Map<produtoCategoria>(model);
                CategoriaRepositorio rep = new CategoriaRepositorio();
                rep.edit(pro);
                model.id = pro.id;
                ret.status = true;
                ret.resultado = model;
                ret.mensagem = "Categoria alterada com sucesso!";
            }
            catch (Exception ex)
            {
                ret.status = false;
                ret.erro = "Erro ao alterar categoria, verifique os dados técnicos: " + ex;
            }
            return ret;
        }


        [HttpGet]
        [Route("allCategorias")]
        public retorno<List<produtoCategoriaModel>> allCategorias(string descricao)
        {
            retorno<List<produtoCategoriaModel>> lista = new retorno<List<produtoCategoriaModel>>();
            try
            {
                if (descricao != null)
                {
                    CategoriaRepositorio rep = new CategoriaRepositorio();
                    List<produtoCategoria> listaProd = rep.getAllDescricao(descricao); // Busca de produtos pela descrição.
                    lista.status = true;
                    var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                    lista.resultado = mapper.Map<List<produtoCategoriaModel>>(listaProd);

                    if (listaProd.Count == 0)
                    {
                        lista.mensagem = "Nenhuma categoria encontrada.";
                    }
                    else
                    {
                        lista.mensagem = "Categoria localizada com sucesso!";
                    }
                    
                }
                else
                {
                    CategoriaRepositorio rep = new CategoriaRepositorio();
                    List<produtoCategoria> listaProd = rep.getAll(); // Busca total em caso de não ter informado nada na descrição.
                    lista.status = true;
                    var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                    lista.resultado = mapper.Map<List<produtoCategoriaModel>>(listaProd);
                    lista.mensagem = "Lista de todas categorias cadastradas.";
                }
            }
            catch (Exception ex)
            {
                lista.status = false;
                lista.erro = "Ocorreu um erro na busca de categorias, verifique os dados técnicos: " + ex;
            }

            return lista;
        }

    }
}
