<% 
  
    Dim objXmlHttp	
	
	Set oXmlHttp = Server.CreateObject("Microsoft.XMLHTTP")		 
	oXmlHttp.Open "POST", "http://localhost:64808/api/cliente", False, "INFORMATICA/dromero", "Madrid13+"
	oXmlHTTP.setRequestHeader "Content-Type", "application/json; charset=utf-8" 	
	oXmlHttp.SetRequestHeader "User-Agent", "ASP/3.0"
	
	'PRUEBA A PELO
	oXmlHttp.Send "{""txNombre"": ""John"",	""txApellido1"": ""Doe"",""txApellido2"": ""Romero"",""txEmail"": ""Romero@artyco.com"",""boPrivacidad"":1,""txOrigen"": ""PRUEBA"",""encuestas"": [{""cdCampa"": ""PRUE"",""txModelo1"": ""Mercedes""	}, {""cdCampa"": ""2RUE"",""txModelo1"": ""Dacia""}]}"
	
    Response.Write(CStr(oXmlHttp.Status) & "</br>")
    Response.Write(CStr(oXmlHttp.ResponseText))

	Set oXmlHttp = Nothing	
	
%>