using Suv_Xojaligi.Data.Entities.Commons;

namespace Suv_Xojaligi.Data.Entities.DWSH_Legal_Documents;

public class Document : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Title { get; set; }
    public string Number { get; set; }
}
