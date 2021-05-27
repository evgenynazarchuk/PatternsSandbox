using System;

namespace ResponsibilityChain
{
    [Flags]
    public enum DocumentStatus
    {
        None = 0,
        Draft = 1,
        OnManagerApproval = 2,
        OnFinancialApproval = 4,
        OnDirectorApproval = 8,
        Completed = 16
    }

    public interface IDocumentStatusHandler
    {
        void Invoke(Document document);
    }

    public abstract class StatusHandler : IDocumentStatusHandler
    {
        protected DocumentStatus _statusHandler { get; set; }

        public StatusHandler(DocumentStatus documentStatus) => _statusHandler = documentStatus;

        // реализация интерфейса
        // если включен флаг статуса, то выполнить действия для этого статуса
        // скорее всего тут нужно только выключать пройденный флаг, 
        // будут выполнять собственный handler для статуса
        // пример:
        // 100 & 101 = 1
        // 100 & 011 = 0
        public bool IsRequiredStatus(IDocumentRequiredStatus document)
            => _statusHandler == (_statusHandler & document.RequiredStatuses);

        // выключить флаг
        // пример
        // включены флаги: 110
        // флаг текущего статуса: 010
        // 110 & ~(010) = 110 & 101 = 100
        public void FinishStatus(IDocumentRequiredStatus document) 
            => document.RequiredStatuses = document.RequiredStatuses & ~_statusHandler;

        public abstract void Invoke(Document document);
    }

    #region status_handler_decorator
    public class DocumentStatusDecorator : IDocumentStatusHandler
    {
        private readonly StatusHandler StatusHandler;

        public DocumentStatusDecorator(StatusHandler statusHandler)
        {
            StatusHandler = statusHandler;
        }

        public void Invoke(Document document)
        {
            if (StatusHandler.IsRequiredStatus(document))
            {
                StatusHandler.Invoke(document);
                StatusHandler.FinishStatus(document);
            }
        }
    }
    #endregion

    #region status_handler
    // а можно ли сделать метод Invoke статическим и использовать декоратор?
    // является ли использование статических методов более быстрым решением?
    public class NoneStatus : StatusHandler
    {
        public NoneStatus() : base(DocumentStatus.None) { }
        public override void Invoke(Document document)
        {
            Console.WriteLine($"Status: {nameof(NoneStatus)}");
        }

        // lazy without singleton class???
        // стоит ли использовать nested class???
        public static IDocumentStatusHandler Instance => NoneStatusSingleton.Instance;
        private static class NoneStatusSingleton
        {
            private static Lazy<StatusHandler> _lazy = new(() => new NoneStatus());
            public static IDocumentStatusHandler Instance => new DocumentStatusDecorator(_lazy.Value);
        }
    }

    public class DraftStatus : StatusHandler
    {
        public DraftStatus() : base(DocumentStatus.Draft) { }
        public override void Invoke(Document document)
        {
            Console.WriteLine($"Status: {nameof(DraftStatus)}");
        }
    }

    public class OnManagerApprovalStatus : StatusHandler
    {
        public OnManagerApprovalStatus() : base(DocumentStatus.OnManagerApproval) { }
        public override void Invoke(Document document)
        {
            Console.WriteLine($"Status: {nameof(OnManagerApprovalStatus)}");
        }
    }

    public class OnFinancialApprovalStatus : StatusHandler
    {
        public OnFinancialApprovalStatus() : base(DocumentStatus.OnFinancialApproval) { }
        public override void Invoke(Document document)
        {
            Console.WriteLine($"Status: {nameof(OnFinancialApprovalStatus)}");
        }
    }

    public class OnDirectorApprovalStatus : StatusHandler
    {
        public OnDirectorApprovalStatus() : base(DocumentStatus.OnDirectorApproval) { }
        public override void Invoke(Document document)
        {
            Console.WriteLine($"Status: {nameof(OnDirectorApprovalStatus)}");
        }
    }

    public class CompletedStatus : StatusHandler
    {
        public CompletedStatus() : base(DocumentStatus.Completed) { }
        public override void Invoke(Document document)
        {
            Console.WriteLine($"Status: {nameof(CompletedStatus)}");
        }
    }
    #endregion

    #region document
    public interface IDocumentRequiredStatus
    {
        public DocumentStatus RequiredStatuses { get; set; }
    }
    
    public class Document : IDocumentRequiredStatus
    {
        public DocumentStatus RequiredStatuses { get; set; }

        public string DocumentName { get => _documentName; }
        private readonly string _documentName;

        public Document(
            string documentName,
            DocumentStatus requiredStatuses)
        {
            RequiredStatuses = requiredStatuses;
            _documentName = documentName;
        }
    }
    #endregion
}
