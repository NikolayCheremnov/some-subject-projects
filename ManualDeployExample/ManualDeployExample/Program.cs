var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "server is running");
app.MapGet("/ping", () => "pong");
app.MapGet("/greeting", (string name) => $"hello, {name}");

/* 
1. ����������� ���-���������� ASP.NET � ����� ENPOINT-��

/ -> "server is running, now time is <������� �����>"

/ping -> "pong"

/info -> <���������� � ������� � ������, �� ������� �������� ��������� (�� ����� 5 ������������� � ����� ����>

2. �������������� ���������� �������� (��������� ���� 8080)

3. ��������� ���������� ���������� � ����� � ������ ����� �� ������� - free asp hosting (�������������� ����������)

4. ������� ����� � ���, �� ����� ������ � ����� ������� �������� free asp hosting

������ ����������:
1) ������ https://freeasphosting.net ����� ���� �� �������� ��� VPN - ����� �������� vpn � �������� (browsec, troywell
2) ��� �������� ������� ������� .net 7 - ���� �� � ��� �� ����������, �� ���������� � ������������ Visual Studio Installer
3) ��� ��������� ������ ��� �������� �� ������, ������������ ���������� ����� public, � �� ���� �����

*/

app.Run();
