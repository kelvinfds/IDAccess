using IDAccess.Interfaces.AccessLogs;
using IDAccess.Interfaces.Biometria;
using IDAccess.Interfaces.DataHora;
using IDAccess.Interfaces.Login;
using IDAccess.Interfaces.Users;
using IDAccess.Interfaces.Relacionamentos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json.Linq;
using IDAccess.Interfaces.Fotos;
using IDAccess.Interfaces.Cartão;

namespace IDAccess
{
    public class WebJson
    {
        static WebJson()
        {
            ServicePointManager.Expect100Continue = false;
        }

        /// <summary>
        /// Reorna uma chave, para ser utilizada nas requisiçoes
        /// </summary>
        /// <param name="uri">uri do equipamento</param>
        /// <param name="_username">Usuario(Login)</param>
        /// <param name="_password">Senha</param>
        /// <returns></returns>
        static public ResponseLogin Conectar(string uri, string _username, string _password)
        {
            var Login = new RequestLogin
            {
                login = _username,
                password = _password
            };
            return Send<ResponseLogin>("http://" + uri + "/login", Login);
        }

        /// <summary>
        /// Envia usuarios para o equipamento, deve possuir a chave gerada na função Conectar 
        /// </summary>
        /// <param name="uri">uri do equipamento</param>
        /// <param name="_id">id do usuario</param>
        /// <param name="nome">nome do usuario</param>
        /// <param name="matricula">matricula do usuario</param>
        /// <param name="chaveSessao">chave retornada pela função Conectar</param>
        /// <returns></returns>
        static public string EnviarUsuario(string uri, long _id, string nome, string matricula, string senha, string salt, string chaveSessao)
        {
            try
            {
            var usuarioSerializado = SerializaDados(new ResponseUsers(_id, nome, matricula,senha,salt), "users");
            return Send("http://" + uri + "/create_objects", usuarioSerializado, false, chaveSessao);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        static public T ExcluirAdmin<T>(string uri, string chaveSessao, long user_id)
        {
            var comando = "{\"object\":\"user_roles\",\"where\":{\"user_roles\":{\"user_id\":[" + user_id + "]}}}";
            return Send<T>("http://" + uri + "/destroy_objects", comando, false, chaveSessao);
        }

        static public string UsuariosAdmin(string uri, long id_Usuario, int role, string chaveSessao)
        {
            var relacionamentoSerializado = SerializaDados(new UsuariosAdmin(id_Usuario, role), "user_roles");
            return Send("http://" + uri + "/create_objects", relacionamentoSerializado, false, chaveSessao);
        }
            static public string GruposeRegras(string uri,long id_Grupo,long id_Regra, string chaveSessao)
        {
            var relacionamentoSerializado = SerializaDados(new GruposeRegras(id_Grupo, id_Regra), "group_access_rules");
            return Send("http://" + uri + "/create_objects", relacionamentoSerializado, false, chaveSessao);
        }
        static public string RegraseHorarios(string uri, long id_Regra, long id_Horario , string chaveSessao)
        {
            var relacionamentoSerializado = SerializaDados(new RegraseHorarios(id_Regra, id_Horario), "access_rule_time_zones");
            return Send("http://" + uri + "/create_objects", relacionamentoSerializado, false, chaveSessao);
        }

        static public string UsuarioseGrupos(string uri, long id_Usuario, long id_Grupo, string chaveSessao)
        {
            var relacionamentoSerializado = SerializaDados(new UsuarioseGrupos(id_Usuario, id_Grupo), "user_groups");
            return Send("http://" + uri + "/create_objects", relacionamentoSerializado, false, chaveSessao);
        }

        
        static public T AlterarUsuario<T>(string uri, string nome, string matricula, string senha, string salt, string chaveSessao, long id)
        {
            var comando = "{\"object\":\"users\",\"where\":{\"users\":{\"id\":[" + id + "]}},\"values\" : {\"name\" : \"" + nome + "\",\"registration\" : \"" + matricula + "\",\"password\" : \"" + senha + "\",\"salt\" : \"" + salt + "\"}}";                        
            return Send<T>("http://" + uri + "/modify_objects", comando, false, chaveSessao);
        }

        static public T ReceberUsuario<T>(string uri, string chaveSessao, long id)
        {
            var comando = "{\"object\":\"users\",\"where\":{\"users\":{\"id\":[" + id + "]}}}";
            return Send<T>("http://" + uri + "/load_objects", comando, false, chaveSessao);
        }

        static public Cards ReceberCartao<Cards>(string uri, string chaveSessao)
        {
            var comando = "{\"object\":\"cards\"}";            
            return Send<Cards>("http://" + uri + "/load_objects", comando, false, chaveSessao);
        }


        static public T ExcluirUsuario<T>(string uri, string chaveSessao, long id)
        {
            var comando = "{\"object\":\"users\",\"where\":{\"users\":{\"id\":[" + id + "]}}}";
            return Send<T>("http://" + uri + "/destroy_objects", comando, false, chaveSessao);
        }

      
        static public string EnviarBiometria(string uri,long _id, string template,long user_id, string chaveSessao)
        {
            var templateSerializado = SerializaDados(new ResponseBiometry(_id, template, user_id), "templates");
            return Send("http://" + uri + "/create_objects", templateSerializado, false, chaveSessao);
        }

        static public string EnviarCartao(string uri, long _id, string value, long user_id, string chaveSessao)
        {
            var card = value.Replace(",","").PadLeft(8,'0');

            var antesVirgula = Convert.ToUInt64(card.Substring(0,3));
            var depoisVirgula = Convert.ToUInt64(card.Substring(3,5));
            var cartao = Convert.ToUInt64((antesVirgula * Math.Pow(2,32)) + depoisVirgula);
            var templateSerializado = SerializaDados(new ResponseCard(_id, cartao, user_id), "cards");
            return Send("http://" + uri + "/create_objects", templateSerializado, false, chaveSessao);
        }

        static public T ExcluirBiometria<T>(string uri, string chaveSessao, long user_id)
        {
            var comando = "{\"object\":\"templates\",\"where\":{\"templates\":{\"user_id\":[" + user_id + "]}}}";
            return Send<T>("http://" + uri + "/destroy_objects", comando, false, chaveSessao);
        }

        static public T ExcluiCartao<T>(string uri, string chaveSessao, long user_id)
        {
            var comando = "{\"object\":\"cards\",\"where\":{\"cards\":{\"user_id\":[" + user_id + "]}}}";
            return Send<T>("http://" + uri + "/destroy_objects", comando, false, chaveSessao);
        }

        public static T CriaHash<T>(string uri, string password, string chaveSessao)
        {            
            var Hash = new HashAdmin
            {
                password = password
            };

            return Send<T>("http://" + uri + "/user_hash_password", Hash, true, chaveSessao);            
        }

        static public string EnviarDataHora(string uri, DateTime data, string chaveSessao)
        {
            try
            {
                var dataEnviar = new RequestDataHora
                {
                    day = data.Day,
                    month = data.Month,
                    year = data.Year,
                    hour = data.Hour,
                    minute = data.Minute,
                    second = data.Second
                };
                return Send("http://" + uri + "/set_system_time", dataEnviar, true, chaveSessao);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
      
        static public string EnviarHorarioVerao(string uri, DateTime inicio, DateTime fim, string chaveSessao)
        {                
            var dataInicio = new start_date_time()
            {
                day = inicio.Day,
                month = inicio.Month,
                year = inicio.Year
            };
            var dataFim = new end_date_time()
            {
                day = fim.Day,
                month = fim.Month,
                year = fim.Year
            };
            var horarioVerao = new RequestHorarioVerao();
            horarioVerao.start_date_time = dataInicio;
            horarioVerao.end_date_time = dataFim;

            return Send("http://" + uri + "/set_system_daylight_saving_time",horarioVerao,true, chaveSessao);
        }

      
        static public infoStatus ReceberStatus<infoStatus>(string uri, string chaveSessao)
        {
            return Send<infoStatus>("http://" + uri + "/system_information", null, false, chaveSessao);
        }

        static public RequestUsers ReceberTodosUsuarios<RequestUsers>(string uri, string chaveSessao)
        {
            var comando = "{\"object\":\"users\"}";
            return Send<RequestUsers>("http://" + uri + "/load_objects", comando, false, chaveSessao);
        }

        static public string RemoverAdministradores(string uri, string chaveSessao)
        {
            return Send("http://" + uri + "/delete_admins", null, false, chaveSessao);
        }

        static public infoBiometry ReceberBiometria<infoBiometry>(string uri,long id, string chaveSessao)
        {
            var comando = "{\"object\":\"templates\",\"where\":{\"users\":{\"id\":["+ id +"]}}}";
            return Send<infoBiometry>("http://" + uri + "/load_objects", comando, false, chaveSessao);
        }

        static public List<LogAcesso> ReceberLogsAcessos(EventTypes tipoRegistro, string uri,long ultimoNSR, string chaveSessao)
        {
            var comando = "{\"order\":[\"descending\",\"id\"],\"where\":{\"access_logs\":{\"id\":{\">\":"+ ultimoNSR +"}}, \"access_logs\":{\"event\":7}},\"object\":\"access_logs\"}";
            var loglist = Send<ResultList>("http://" + uri + "/load_objects", comando, false, chaveSessao);
            List<LogAcesso> Logs = new List<LogAcesso>();
            foreach (var item in loglist.access_logs)
            {
                if (item.Event == 7)
                    Logs.Add(new LogAcesso(item.id, item.user_id, item.Event, item.Date, item.device_id, item.identifier_id));
            }
            return Logs;
        }

        /// <summary>
        /// Função que serializa os dados para ser enviado para o equipamento
        /// </summary>
        /// <param name="dados">dados que irão ser serializados</param>
        /// <param name="_objeto">tipo de objeto que será passado para o equipamento</param>
        /// <returns></returns>
        static public string SerializaDados(object dados, string _objeto)
        {
            var dadosEstrutura = new Dados()
            {
                objeto = _objeto, //sera substituido pela palavra "object"
                values = "dados" //dados sera substituido pela serialização dos dados
            };

            var estuturaSerializada = JsonConvert.SerializeObject(dadosEstrutura);

            var dadosSerializado = JsonConvert.SerializeObject(dados);

            return estuturaSerializada.Replace("objeto", "object").Replace("\"dados\"", "[" + dadosSerializado + "]");
        }

        static public string Send(string uri, object dados, bool serializar = true, string session = null)
        {
            var dadosSerializados = serializar ? JsonConvert.SerializeObject(dados) : dados;

            uri += (session != null) ? ".fcgi?session=" + session : ".fcgi";

            try
            {
                var requisicao = (HttpWebRequest)WebRequest.Create(uri);
                requisicao.ContentType = "application/json";
                requisicao.Method = "POST";

                using (var streamWriter = new StreamWriter(requisicao.GetRequestStream()))
                {
                    streamWriter.Write(dadosSerializados);
                }

                var resposta = (HttpWebResponse)requisicao.GetResponse();

                using (var streamReader = new StreamReader(resposta.GetResponseStream()))
                {
                    var retornoLido = streamReader.ReadToEnd();
                    if (uri.Contains("delete_admins"))
                    {
                        return "";
                    }
                    else
                    return JsonConvert.DeserializeObject(retornoLido).ToString();                    
                }

            }
            catch (WebException e)
            {
                if (e.InnerException == null)
                {                    
                    return e.Message;
                }
                else
                {
                    return e.InnerException.Message.ToString();
                }
            }
        }
        
        static public T Send<T>(string uri, object dados, bool serializar = true, string session = null)
        {
            var dadosSerializados = (serializar) ? JsonConvert.SerializeObject(dados) : dados;

            uri += session != null ? ".fcgi?session=" + session : ".fcgi";

            try
            {
                var requisicao = (HttpWebRequest)WebRequest.Create(uri);
                requisicao.ContentType = "application/json";
                requisicao.Method = "POST";

                using (var streamWriter = new StreamWriter(requisicao.GetRequestStream()))
                {
                    streamWriter.Write(dadosSerializados);
                }

                var resposta = (HttpWebResponse)requisicao.GetResponse();
                
                using (var streamReader = new StreamReader(resposta.GetResponseStream()))
                {
                    var retornoLido = streamReader.ReadToEnd();

                    if (retornoLido.Contains("templates"))
                    {
                        var t = deserializerTemplate.JsonHelper.DeSerializar<T>(retornoLido);
                        return t;
                    }

                    return JsonConvert.DeserializeObject<T>(retornoLido);
                    
                }
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    using (Stream responseData = response.GetResponseStream())
                    using (var reader = new StreamReader(responseData))
                    {
                        throw new Exception(reader.ReadToEnd());
                    }
                }
            }
        }
    }
}
