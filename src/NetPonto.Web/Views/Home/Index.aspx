<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<NetPonto.Web.Models.Home.Index>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="colLeft">
        <h2>
            Bem-vindo(a) à Comunidade NetPonto!</h2>
        <div style="float:right">
            <img src="http://lh3.ggpht.com/_U5LLWU4M8cA/TJif28EEl7E/AAAAAAAAEzQ/9Yk6JFdVRvY/s160-c/14Reuniao18092010.jpg"
                border="0" />
        </div>
        <div style="float:left;width:70%">
            A comunidade NetPonto é uma iniciativa independente e sem fins lucrativos, que tem
            como simples e &uacute;nico objectivo a partilha de conhecimento na &aacute;rea
            de arquitectura e desenvolvimento de software na plataforma .NET, na tentativa de
            disseminar o conhecimento diferenciado de cada um de seus membros.<br />
            <br />
            Cada um de n&oacute;s tem diferentes talentos, e com as dezenas de tecnologias que
            s&atilde;o lan&ccedil;adas todos os dias, &eacute; muito dif&iacute;cil (para n&atilde;o
            dizer imposs&iacute;vel) estar por dentro de tudo, e essa &eacute; uma das principais
            vantagens em fazer parte de uma comunidade de pessoas ligadas &agrave; nossa &aacute;rea.<br />
            <br />
            Podemos aprender mais, e mais r&aacute;pido, com as experi&ecirc;ncias de cada um.
        </div>
        <div class="clearfix"></div>
        <div style="display:block">
        <hr style="margin:10px"/>

        <h2><%= Html.Encode(Model.Name) %></h2>
        <div><%=Model.Description %>
        </div>
        <h3>
        Agenda
        </h3>
        <table width="100%" cellspacing="0" cellpadding="0" border="0">
            <tbody>
            <% foreach(var part in Model.Schedule){ %>
                <tr>
                    <td nowrap="true">
                        <%= part.Hours%>:<%= part.Minutes%>
                    </td>
                    <td nowrap="true">
                        &nbsp;-&nbsp;
                    </td>
                    <td width="100%">
                        <strong>
                            <%= part.Name %></strong>
                        <% if (!string.IsNullOrEmpty(part.UserDisplayName)) {  %>
                        &nbsp;-&nbsp;
                        <a href="<%=part.UserUrl %>">
                            <%= part.UserDisplayName %></a>
                            <%} %>
                    </td>
                    
                </tr>
                <% if (!string.IsNullOrEmpty(part.Description)) {  %>
                <tr>
				    <td nowrap="true">&nbsp;</td>
				    <td nowrap="true">&nbsp;</td>
				    <td width="100%"><%= part.Description %></td>
                </tr>
                <% } %>
            <% } %>
            </tbody>
        </table>

        <div  class="paragraph" style=" text-align: left; display: block; ">Nota: Ao final da reunião, normalmente escolhemos um restaurante próximo e fazemos um almoço em grupo para continuar o convívio e aproximar as pessoas. A participação é opcional.</div>

        <div ><div style="height: 20px; overflow: hidden; width: 100%;"></div>
		<hr style="background-color:#777777; border:0pt none; color:#777777; height:1px; margin:0 auto; text-align: center; width:100%;"></hr>
		<div style="height: 20px; overflow: hidden; width: 100%;"></div></div>

		<h2  ><a name="registo" style="color:#000000">Registo / Inscrição</a></h2>
		<div class="paragraph" style=" text-align: left; display: block; ">Para participar, basta <a href="http://netponto-lisboa-outubro-2010.eventbrite.com/" title="Efectue sua inscrição" style="color:#0000ff">efectuar a inscrição</a> através do site <a href="http://netponto-lisboa-outubro-2010.eventbrite.com/" title="Efectue sua inscrição" style="color:#0000ff">http://netponto-lisboa-outubro-2010.eventbrite.com/</a>.<br />A entrada é gratuita.<br /><br />Qualquer dúvida / esclarecimento, <a href="mailto:contacto@netponto.org?subject=Contacto" title="Entre em contacto connosco!" style="color:#0000FF">entre em contacto</a> connosco.</div>

		
		<div ><div style="height: 20px; overflow: hidden; width: 100%;"></div>
		<hr style="background-color:#777777; border:0pt none; color:#777777; height:1px; margin:0 auto; text-align: center; width:100%;"></hr>
		<div style="height: 20px; overflow: hidden; width: 100%;"></div></div>
		
		<h2  style=" text-align: left; "><FONT color="#000000"><a name="local" style="color:#000000">Local</a></FONT></h2>
		<div class="paragraph" style=" text-align: left; display: block; "><strong>Novabase (Lisboa)</strong><br />Av. D. João II, Lote 1.03.2.3, Parque das Nações<br />1998-031 Lisboa</div>

		<div><div style="text-align: left;"><a href="http://www.google.pt/maps?f=q&source=s_q&hl=pt-PT&geocode=&q=Novabase&sll=38.769861,-9.099233&sspn=0.009971,0.022638&g=2+Av.+Dom+Jo%C3%A3o+II,+Lisboa,+1990&ie=UTF8&hq=Novabase&hnear=Av.+Dom+Jo%C3%A3o+II+2,+Lisboa&ll=38.765888,-9.097951&spn=0.002493,0.005659&z=18&iwloc=C" target="_blank">
            <img src="<%= Url.Image("mapa-novabase.png") %>" style="margin-top: 10px; margin-bottom: 10px; margin-left: 0; margin-right: 10px; border: none;" alt="" /></a><div style="display: block; font-size: 90%; margin-top: -10px; margin-bottom: 10px;">Clique para ampliar o mapa.</div></div></div>

		<div ><div style="height: 20px; overflow: hidden; width: 100%;"></div>
		<hr style="background-color:#777777; border:0pt none; color:#777777; height:1px; margin:0 auto; text-align: center; width:100%;"></hr>
		<div style="height: 20px; overflow: hidden; width: 100%;"></div></div>
		
		<div class="paragraph" style="text-align: left; display: block; font-size:1.20em;">
			Mais Comunidade NetPonto:<br /><br />
			<ul>
				<li>Lista de Discussão: <a href="http://groups.google.com/group/netponto" title="Participe das nossas listas de discussão!" style="color:#0000ff">NetPonto</a>, <a href="http://groups.google.com/group/netpontonews" title="Participe das nossas listas de discussão!" style="color:#0000ff">NetPontoNews</a>, e <a href="http://groups.google.com/group/netpontojobs" title="Participe das nossas listas de discussão!" style="color:#0000ff">NetPontoJobs</a></li>

				<li>Twitter: <a href="http://twitter.com/NetPonto" title="Siga-nos no Twitter!" style="color:#0000ff">NetPonto</a>, <a href="http://twitter.com/NetPontoNews" title="Siga-nos no Twitter!" style="color:#0000ff">NetPontoNews</a>, e <a href="http://twitter.com/NetPontoJobs" title="Siga-nos no Twitter!" style="color:#0000ff">NetPontoJobs</a></li>
				<li>Apresentações: <a href="http://www.slideshare.net/netponto" title="Veja os slides das apresentações que já fizemos!" style="color:#0000ff">Slides das Apresentações</a></li>
				<li>Fotos: <a href="http://picasaweb.google.com/netponto.org/" title="Veja as fotos das reuniões anteriores!" style="color:#0000ff">Fotos das Reuniões</a></li>
				<li>LinkedIn: <a href="http://www.linkedin.com/groups?gid=2200254" title="Faça parte do nosso grupo no LinkedIn!" style="color:#0000ff">Grupo NetPonto</a></li>

			</ul>
		</div>


    </div>
</div>
</asp:Content>
