<% 
    Dim objXmlHttp	
	Set oXmlHttp = Server.CreateObject("Microsoft.XMLHTTP")		 
	oXmlHttp.Open "POST", "http://localhost:64808/api/cliente", False, "DOMAIN/user", "password+"
	oXmlHTTP.setRequestHeader "Content-Type", "application/json; charset=utf-8" 	
	oXmlHttp.SetRequestHeader "User-Agent", "ASP/3.0"
	oXmlHttp.Send "{""name"": ""John"",	""last_name"": ""Doe"",""ident_doc"": ""5898965M"",""email"": ""romero@hotmail.com"",""lopd"":1,""web_origin"": ""www.PRUEBA.com"",""encuestas"": [{""cd_campa"": ""PRUE"",""model1"": ""Audi A3""	}, {""cd_campa"": ""2RUE"",""model1"": ""Dacia Logan""}]}"
    Response.Write(CStr(oXmlHttp.Status) & "</br>")
    Response.Write(CStr(oXmlHttp.ResponseText))
	Set oXmlHttp = Nothing	
%>