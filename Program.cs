class Program
{
    private const string PRO_LICENSE = "00000";
    private const string EXP_LICENSE = "11111";
 
    static void Main(string[] args)
    {
        Console.Write("Введіть ключ:");
        var license = Console.ReadLine();
 
        DocumentWorker worker;
        switch (license)
        {
            case PRO_LICENSE: worker = new ProDocumentWorker(); break;
            case EXP_LICENSE: worker = new ExpertDocumentWorker(); break;
            default: worker = new DocumentWorker(); break;
        }
 
        while (true)
        {
            Console.WriteLine("Оберіть дію: 1 - відкрити документ, 2 - редагувати документ, 3 - зберегти документ, 4 - закрити: ");
            switch (Console.ReadLine())
            {
                case "1": worker.OpenDocument(); break;
                case "2": worker.EditDocument(); break;
                case "3": worker.SaveDocument(); break;
                case "4": return;
            }
        }
    }
}

class DocumentWorker
{
    public virtual void OpenDocument()
    {
        Console.WriteLine("Документ відкритий");
    }
    public virtual void EditDocument()
    {
        Console.WriteLine("Правка документа доступна у версії Про");
    }
    public virtual void SaveDocument()
    {
        Console.WriteLine("Збереження документа доступне у версії Про");
    }
}
class ProDocumentWorker:DocumentWorker
{
    public override void EditDocument()
    {
        Console.WriteLine("Документ відредаговано");
    }
    public override void SaveDocument()
    {
        Console.WriteLine("Документ збережено у старому форматі, збереження в інших форматах доступне у версії Експерт");
    }
}
class ExpertDocumentWorker:ProDocumentWorker
{
    public override void SaveDocument()
    {
        Console.WriteLine("Документ збережений в новому форматі");
    }
}