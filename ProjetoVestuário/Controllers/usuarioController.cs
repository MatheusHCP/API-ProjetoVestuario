using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades;
using ProjetoVestuário.Model;
using AutoMapper;
using Repositorio;
using Microsoft.AspNetCore.Authorization;

namespace ProjetoVestuário.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usuarioController : ControllerBase
    {
        [HttpPost]
        public retorno<usuarioModel> criarUsuario(usuarioModel model)
        {
            retorno<usuarioModel> ret = new retorno<usuarioModel>();
            try
            {
                usuarioRepositorio rep = new usuarioRepositorio();
                Usuario verificar = rep.emailecpfexistente(model.usu_email, model.usu_cpf);

                if (verificar != null)
                {
                    ret.status = false;
                    ret.mensagem = "Email ou CPF já cadastrados, verifique o cadastro.";
                }
                else
                {
                    var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                    model.usu_dataCriacao = DateTime.Now;
                    Usuario pro = mapper.Map<Usuario>(model);
                    rep.add(pro);
                    model.id = pro.id;

                    usuarioEndereco usuEndereco = new usuarioEndereco()
                    {
                        id = 0,
                        Usuarioid = model.id,
                        end_descricao = model.usuarioEnderecoModel.end_descricao,
                        end_endereco = model.usuarioEnderecoModel.end_endereco,
                        end_numero = model.usuarioEnderecoModel.end_numero,
                        end_complemento = model.usuarioEnderecoModel.end_complemento,
                        end_bairro = model.usuarioEnderecoModel.end_bairro,
                        end_cidade = model.usuarioEnderecoModel.end_cidade,
                        end_estado = model.usuarioEnderecoModel.end_estado,
                        end_CEP = model.usuarioEnderecoModel.end_CEP,
                        end_referencia = model.usuarioEnderecoModel.end_referencia
                    };
                    (new usuarioEnderecoRepositorio()).add(usuEndereco);
                    ret.status = true;
                    ret.resultado = model;
                    ret.mensagem = "Usuário cadastrado com sucesso!";

                }
            }
            catch (Exception ex)
            {
                ret.status = false;
                ret.mensagem = "Erro ao cadastrar novo usuário (:/), verifique os dados técnicos: " + ex;
                throw;
            }

            return ret;
        }

        [Authorize]
        [HttpDelete]
        public retorno<usuarioModel> apagarUsuario(int id)
        {
            retorno<usuarioModel> ret = new retorno<usuarioModel>();
            try
            {
                usuarioRepositorio rep = new usuarioRepositorio();
                Usuario pro = rep.get(id);

                if (pro == null)
                {
                    ret.status = false;
                    ret.erro = "Não foi possível localizar o usuário para efetuar o delete.";
                }
                else
                {
                    rep.delete(pro);
                    ret.status = true;
                    ret.mensagem = "Usuário localizado e apagado com sucesso!";
                    var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                    ret.resultado = mapper.Map<usuarioModel>(pro);
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
        public retorno<usuarioModel> alterarUsuario(usuarioModel model)
        {
            retorno<usuarioModel> ret = new retorno<usuarioModel>();

            try
            {
                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                Usuario pro = mapper.Map<Usuario>(model);
                usuarioRepositorio rep = new usuarioRepositorio();
                rep.edit(pro);
                model.id = pro.id;

                ret.status = true;
                ret.resultado = model;
                ret.mensagem = "Usuario alterado com sucesso!";
            }
            catch (Exception ex)
            {
                ret.status = false;
                ret.erro = "Erro ao alterar Usuario, verifique os dados técnicos: " + ex;
            }
            return ret;
        }
    }
}
