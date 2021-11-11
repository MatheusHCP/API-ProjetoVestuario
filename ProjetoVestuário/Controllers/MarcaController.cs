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
    public class MarcaController : ControllerBase
    {

        [HttpGet]
        public retorno<produtoMarcaModel> GetMarca(int id)
        {
            retorno<produtoMarcaModel> ret = new retorno<produtoMarcaModel>();
            try
            {
                MarcaRepositorio rep = new MarcaRepositorio();
                produtoMarca pro = rep.get(id);

                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                ret.resultado = mapper.Map<produtoMarcaModel>(pro);

                if (pro == null)
                {
                    ret.status = false;
                    ret.mensagem = "Marca não localizada (:/), verifique a escrita.";
                }
                else
                {
                    ret.status = true;
                    ret.mensagem = "Marca Localizada!";
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
        public retorno<produtoMarcaModel> InserirMarca(produtoMarcaModel model)
        {
            retorno<produtoMarcaModel> ret = new retorno<produtoMarcaModel>();
            try
            {
                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                produtoMarca pro = mapper.Map<produtoMarca>(model);
                MarcaRepositorio rep = new MarcaRepositorio();
                rep.add(pro);
                model.id = pro.id;
                ret.status = true;
                ret.resultado = model;
                ret.mensagem = "Marca cadastrada com sucesso!";

            }
            catch (Exception ex)
            {
                ret.status = false;
                ret.erro = "Erro ao cadastrar nova marca (:/), verifique os dados técnicos: " + ex;
                throw;
            }

            return ret;
        }

        [Authorize]
        [HttpDelete]
        public retorno<produtoMarcaModel> apagarMarca(int id)
        {
            retorno<produtoMarcaModel> ret = new retorno<produtoMarcaModel>();
            try
            {
                MarcaRepositorio rep = new MarcaRepositorio();
                produtoMarca pro = rep.get(id);
                if (pro == null)
                {
                    ret.status = false;
                    ret.erro = "Não foi possível localizar a marca para efetuar o delete.";
                }
                else
                {
                    rep.delete(pro);
                    ret.status = true;
                    ret.mensagem = "Marca localizada e apagada com sucesso!";
                    var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                    ret.resultado = mapper.Map<produtoMarcaModel>(pro);
                }
            }
            catch (Exception ex)
            {
                ret.status = false;
                ret.erro = "Erro ao deletar marca, verifique os dados técnicos: " + ex;
                throw;
            }

            return ret;
        }

        [Authorize]
        [HttpPut]
        public retorno<produtoMarcaModel> alterarMarca(produtoMarcaModel model)
        {
            retorno<produtoMarcaModel> ret = new retorno<produtoMarcaModel>();

            try
            {
                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                produtoMarca pro = mapper.Map<produtoMarca>(model);
                MarcaRepositorio rep = new MarcaRepositorio();
                rep.edit(pro);
                model.id = pro.id;
                ret.status = true;
                ret.resultado = model;
                ret.mensagem = "Marca alterada com sucesso!";
            }
            catch (Exception ex)
            {
                ret.status = false;
                ret.erro = "Erro ao alterar marca, verifique os dados técnicos: " + ex;
            }
            return ret;
        }


        [HttpGet]
        [Route("allMarcas")]
        public retorno<List<produtoMarcaModel>> allMarcas(string descricao)
        {
            retorno<List<produtoMarcaModel>> lista = new retorno<List<produtoMarcaModel>>();
            try
            {
                if (descricao != null)
                {
                    MarcaRepositorio rep = new MarcaRepositorio();
                    List<produtoMarca> listaProd = rep.getAllDescricao(descricao); // Busca de produtos pela descrição.
                    lista.status = true;
                    var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                    lista.resultado = mapper.Map<List<produtoMarcaModel>>(listaProd);
                    if (listaProd.Count == 0)
                    {
                        lista.mensagem = "Nenhuma marca encontrada.";
                    }
                    else
                    {
                        lista.mensagem = "Marca localizada com sucesso!";
                    }
                    

                }
                else
                {
                    MarcaRepositorio rep = new MarcaRepositorio();
                    List<produtoMarca> listaProd = rep.getAll(); // Busca total em caso de não ter informado nada na descrição.
                    lista.status = true;
                    var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                    lista.resultado = mapper.Map<List<produtoMarcaModel>>(listaProd);
                    lista.mensagem = "Lista de todas marcas cadastradas.";
                }
            }
            catch (Exception ex)
            {
                lista.status = false;
                lista.erro = "Ocorreu um erro na busca de marcas, verifique os dados técnicos: " + ex;
            }

            return lista;
        }

    }
}
