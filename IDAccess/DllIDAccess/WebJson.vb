Imports System
Imports System.IO
Imports System.Net
Imports System.Net.Http
'Imports System.Runtime.Serialization.Json;
Imports Newtonsoft.Json

Imports System.Text

Public Class WebJson

    Shared Sub WebJson()
        ServicePointManager.Expect100Continue = False
    End Sub

    Public Shared Async Function SendAsync(ByVal uri As String, ByVal data As String, ByVal session As String) As Task(Of String)

        If (session Is Nothing) Then
            uri &= ".fcgi?session=" & session
        Else
            uri &= ".fcgi"
        End If

        Dim reto = String.Empty

        Try
            Dim postReq = DirectCast(WebRequest.Create(uri), HttpWebRequest)
            postReq.Method = "POST"
            postReq.ContentType = "application/json"


            Using streamWriter As New StreamWriter(postReq.GetRequestStream(), System.Text.Encoding.UTF8)
                streamWriter.Write(data)
            End Using

            'Dim response = postReq.GetResponse()

            'Using streamReader As New StreamReader(response.GetResponseStream())
            ' Return streamReader.ReadToEnd()
            ' End Using

            Dim stream As Stream = postReq.GetResponse().GetResponseStream()

            Dim reader As New StreamReader(stream)

            Dim response As String = String.Empty



            Dim newStream As Stream = postReq.GetRequestStream()



            While response = reader.ReadLine()

                response += reader.ReadLine()

            End While





        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        '  Try
        'Using client = New HttpClient()
        '    Using response = Await client.GetAsync(uri)
        '        If response.IsSuccessStatusCode Then
        '            Dim retornoWeb = Await response.Content.ReadAsStringAsync()
        '            Dim ret = JsonConvert.DeserializeObject(Of ConexaoResponse())(retornoWeb).ToList()
        '        Else
        '            MsgBox("Não foi possível obter o produto : " + response.StatusCode)
        '        End If
        '    End Using
        'End Using
        'Dim request = Htt(HttpWebRequest) WebRequest.Create(uri)
        'request.ContentType = "application/json";
        'request.Method = "POST";

        'Using (var streamWriter = New StreamWriter(request.GetRequestStream()))
        '{
        '    StreamWriter.Write(data);
        '}

        'var response = (HttpWebResponse)request.GetResponse();
        'Using (var streamReader = New StreamReader(response.GetResponseStream()))
        '{
        '    Return StreamReader.ReadToEnd();
        '}

        '  Catch e As Exception

        'MsgBox(e.Message)
        '    Using (WebResponse response = e.Response)
        '    {
        '        HttpWebResponse httpResponse = (HttpWebResponse)response;
        '        Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
        '        Using (Stream responseData = response.GetResponseStream())
        '        Using (var reader = New StreamReader(responseData))
        '        {
        '            Throw New Exception(reader.ReadToEnd());
        '        }
        '    }
        '  End Try
        Return reto
    End Function

    '    // Rotina com parser Json de saída (a entrada 'data' poderia ter a mesma logica, mas para não complicar muito vou fazer apenas a saida)
    '    // Veja como seria a rotina completa neste outro exemplo: https://github.com/controlid/RepCid/blob/master/test-CS-Futronic/RestJSON.cs
    '    Public Static T Send<T>(String uri, String data, String session = null)
    '    {
    '        If (session! = null)
    '            uri += ".fcgi?session=" + session;
    '        Else
    '            uri += ".fcgi";

    '        Try
    '        {
    '            var request = (HttpWebRequest)WebRequest.Create(uri);
    '            request.ContentType = "application/json";
    '            request.Method = "POST";

    '            Using (var streamWriter = New StreamWriter(request.GetRequestStream()))
    '            {
    '                streamWriter.Write(data);
    '            }

    '            // Fica até menor a rotina!
    '            var response = (HttpWebResponse)request.GetResponse();
    '            var serializer = New DataContractJsonSerializer(TypeOf (T));
    '            Return (T)serializer.ReadObject(response.GetResponseStream());
    '        }
    '        Catch (WebException e)
    '        {
    '            Using (WebResponse response = e.Response)
    '            {
    '                HttpWebResponse httpResponse = (HttpWebResponse)response;
    '                Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
    '                Using (Stream responseData = response.GetResponseStream())
    '                Using (var reader = New StreamReader(responseData))
    '                {
    '                    Throw New Exception(reader.ReadToEnd());
    '                }
    '            }
    '        }
    '    }
    '}
End Class

