Imports IDAccess
Imports IDAccess.Interfaces.AccessLogs
Imports IDAccess.Interfaces.Status
Imports IDAccess.Interfaces.Users
Imports IDAccess.Interfaces.Biometria
Imports IDAccess.ExtenderUtil
Imports IDAccess.Interfaces.Cartão

Module Module1
    Sub Main()

        Dim respostaLogin = WebJson.Conectar("192.168.0.247", "admin", "admin")

        Dim chaveSessao = respostaLogin.session

        If String.IsNullOrEmpty(chaveSessao) Then
            Console.WriteLine("Não foi possivel logar")
            Return
        End If

        'Try
        '    Console.WriteLine(WebJson.CriaHash("192.168.0.245:3000", "kelvin123", chaveSessao))
        'Catch ex As Exception
        '    Console.WriteLine(ex.Message)
        'End Try

        Try
            Dim h = DateTime.Now
            Console.WriteLine(WebJson.EnviarDataHora("192.168.0.245:3000", h, chaveSessao))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'Try
        '    Dim inicio = Convert.ToDateTime("20112019")
        '    Dim fim = Convert.ToDateTime("05022020")
        '    WebJson.EnviarHorarioVerao("192.168.0.129", inicio, fim, chaveSessao)
        'Catch ex As Exception
        '    Console.WriteLine(ex)
        'End Try

        'Try
        '    Console.WriteLine(WebJson.AlterarUsuario(Of RequestUsers)("192.168.0.129", "TKelvin Ferreira Dos Santos", "5", chaveSessao, 12345678900))
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        'Try
        '    Console.WriteLine(WebJson.ExcluirUsuario(Of RequestUsers)("192.168.0.129", chaveSessao, 12345678900))
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        'Dim inicio = ToUnix(DateTime.Today)
        'Dim fim = ToUnix(DateTime.Now)

        'Try
        '    Console.WriteLine(WebJson.EnviarUsuario("192.168.0.247", 6, "Norma de Jesus", "6", chaveSessao))
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try


        'Try
        '    Dim t = WebJson.ReceberCartao(Of RequestCard)("192.168.0.247", chaveSessao)
        '    Dim depoisVirgula = t.cards(0).value Mod 2 ^ 32
        '    Dim antesVirgula = t.cards(0).value / 2 ^ 32
        '    Dim cartao = Convert.ToInt32(antesVirgula) & "," & depoisVirgula
        '    Dim o = 0
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        'Try
        '    Console.WriteLine(WebJson.UsuarioseGrupos("192.168.0.129", 3, 1, chaveSessao))
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        'Try
        '    Console.WriteLine(WebJson.GruposeRegras("192.168.0.129", 1, 1, chaveSessao))
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try




        'Try
        '    Dim g = WebJson.ReceberUsuario(Of RequestUsers)("192.168.0.129", chaveSessao, 34487)
        '    Console.WriteLine(g)
        '    For Each item In g.users
        '        Console.WriteLine("Id: " & item.id & " Nome: " & item.name & " Matricula: " & item.registration)
        '    Next
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try


        'Try
        '    Dim q = WebJson.ReceberStatus(Of infoStatus)("192.168.0.129", chaveSessao)
        '    Console.WriteLine("dia: " & q.uptime.days)
        '    Console.WriteLine("horas: " & q.uptime.hours)
        '    Console.WriteLine("minutos: " & q.uptime.minutes)
        '    Console.WriteLine("segundos: " & q.uptime.seconds)
        '    Console.WriteLine("tempo: " & q.time)
        '    Console.WriteLine("mac: " & q.network.mac)
        '    Console.WriteLine("ip: " & q.network.ip)
        '    Console.WriteLine("netmask: " & q.network.netmask)
        '    Console.WriteLine("gateway: " & q.network.gateway)
        '    Console.WriteLine("Serial: " & q.serial)
        '    Console.WriteLine("Versão: " & q.version)
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try


        'Try
        '    Dim u = WebJson.ReceberTodosUsuarios(Of RequestUsers)("192.168.0.129", chaveSessao)
        '    Dim test As New User

        '    For Each item In u.users
        '        Console.WriteLine("Id: " & item.id & " Nome: " & item.name & " Matricula: " & item.registration)
        '        test.name = item.name
        '        test.id = item.id
        '        test.registration = item.registration
        '    Next



        '    Console.WriteLine(" ")
        '    Console.WriteLine(" ")
        '    Console.WriteLine(" ")
        '    Console.WriteLine("------------ Agora Vai -------------- ")
        '    Console.WriteLine(" ")
        '    Console.WriteLine(" ")
        '    Console.WriteLine(test)
        '    'test.name = u.users

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        'Try
        '    Dim ids() As Long = {12345678900, 100066}

        '    Dim t = WebJson.ReceberBiometria(Of infoBiometry)("192.168.0.129", 12345678900, chaveSessao)

        '    Dim a = t.templates.ToArray().Length


        '    Console.WriteLine(t.templates.Item(0).template)
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        'Try
        '    Dim g = WebJson.ReceberLogsAcessos(EventTypes.all, "192.168.0.129", 390, chaveSessao)

        '    Console.WriteLine(g.Item(0).IdUsuario & " " & g.Item(0).IdDispositivo & " " & g.Item(0).IdIdentificador & " " & g.Item(0).NSR & " " & g.Item(0).Evento & " " & g.Item(0).DataHora)
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try


        'Try
        '    Dim q = WebJson.EnviarBiometria("192.168.0.129", 100065, "templatetestejgfkjhbafds", 12345678900, chaveSessao)
        '    Console.WriteLine(q)
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        'Try
        '    Dim q = WebJson.ExcluirBiometria(Of ResponseBiometry)("192.168.0.129", chaveSessao, 12345678900)
        'Catch ex As Exception
        '    Console.WriteLine(ex.Message)
        'End Try

        'Try
        '    WebJson.RemoverAdministradores("192.168.0.129", chaveSessao)
        'Catch ex As Exception
        '    Console.WriteLine(ex.Message)
        'End Try

        'Try

        '    'WebJson.EnviaImagem("192.168.0.247", {12345678900}, chaveSessao)
        'Catch ex As Exception
        '    Console.WriteLine(ex.Message & vbCrLf & ex.InnerException.ToString())
        'End Try


        'Try
        '    Dim valor = "18027697"
        '    WebJson.EnviarCartao("192.168.0.247", 24716314, 1060856938426, 19, chaveSessao)
        'Catch ex As Exception
        '    Console.WriteLine(ex.Message & vbCrLf & ex.InnerException.ToString())
        'End Try

    End Sub

End Module