using System.Collections.Generic;

namespace WebLab1_Levchenko.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
public class MenuItem
{
    // �������� �� ��������� ��� ������� �����������
    public bool IsPage { get; set; } = false;
    // ��� �������
    public string Area { get; set; } = "";
    // ��� �������� �����������
    public string Action { get; set; } = "";
    // ��� �����������
    public string Controller { get; set; } = "";
    // ��� ��������
    public string Page { get; set; } = "";
    // ����� CSS ��� �������� ������ ����
    public string Active { get; set; } = "";
    // ����� �������
    public string Text { get; set; } = "";

}
