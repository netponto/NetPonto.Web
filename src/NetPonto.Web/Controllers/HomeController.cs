using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetPonto.Web.Models.Home;

namespace NetPonto.Web.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new Index()
                            {
                                Name = "15ª Reunião Presencial da Comunidade NetPonto",
                                Description =
                                    @"No dia 23/10/2010 será realizada a 15ª reunião presencial da comunidade NetPonto, em Lisboa.
Para participar, <a href=""#registo"" title=""Efectue o registo"" style=""color: rgb(0, 0, 255);"">efectue o registo</a>
de acordo com as <a href=""#registo"" title=""Efectue o registo"" style=""color: rgb(0, 0, 255);"">instruções abaixo</a>.<br><br>",
                                Schedule =
                                    {
                                        new Index.SchedulePart()
                                            {
                                                Hours = "9",
                                                Minutes = "30",
                                                Name = "Recepção dos participantes",
                                                Description = string.Empty,
                                            },
                                        new Index.SchedulePart()
                                            {
                                                Hours = "10",
                                                Minutes = "00",
                                                Name = "Biztalk Server 2010: Introdução",
                                                Description =
                                                    @"Nesta sessão o <a href=""http://pt.linkedin.com/pub/jo%C3%A3o-faneca/0/5ba/705"" title=""Clique para conhecer o perfil do João Faneca no LinkedIn"" target=""_blank"" style=""color: rgb(0, 0, 255);"">João</a> vai nos mostrar o que é o Biztalk e para que serve, bem como explicar a sua arquitectura e principais componentes, juntamente com diversas demonstrações de suas funcionalidades, como por exemplo orquestrações com consumo de ficheiros, serviços WCF, construção de <em>Custom Adapters</em>, entre outras demonstrações, com ênfase nas novidades da versão 2010 do Biztalk.",
                                                UserDisplayName = "João Faneca",
                                                UserUrl = "http://pt.linkedin.com/pub/jo%C3%A3o-faneca/0/5ba/705"
                                            },
                                        new Index.SchedulePart()
                                            {
                                                Hours = "11",
                                                Minutes = "30",
                                                Name = "Coffee-break",
                                                Description = string.Empty,
                                            },
                                        new Index.SchedulePart()
                                            {
                                                Hours = "12",
                                                Minutes = "00",
                                                Name = "Práticas de Programação em .NET",
                                                Description =
                                                    @"Nesta sessão o <a href=""http://pt.linkedin.com/in/rmalves"" title=""Clique para conhecer o perfil do Ricardo Alves no LinkedIn"" target=""_blank"" style=""color: rgb(0, 0, 255);"">Ricardo</a> vai nos mostrar algumas das principais práticas utilizadas no desenvolvimento profissional de software na plataforma Microsoft .NET. Serão abordados temas como convenções e padrões de codificação em equipa e validação do código, diferentes formas estruturar uma solução, uma solução vs múltiplas soluções e quando faz sentido, princípios diversos como DRY, SOLID, KISS, YAGNI com demonstrações práticas, testes unitários, e mais...",
                                                UserDisplayName = "Ricardo Alves",
                                                UserUrl = "http://pt.linkedin.com/in/rmalves",
                                            },
                                        new Index.SchedulePart()
                                            {
                                                Hours = "13",
                                                Minutes = "30",
                                                Name = "Painel de Discussão",
                                                Description = string.Empty,
                                            },
                                    }
                            };

            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
