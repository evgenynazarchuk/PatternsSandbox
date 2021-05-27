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

    public interface IStatusHandler
    {
        void Service(Document document);
        bool IsRequiredStatus(Document document);
        void FinishStatus(Document document);
    }

    public abstract class StatusHandler : IStatusHandler
    {
        protected DocumentStatus _documentStatus { get; set; }
        public StatusHandler(DocumentStatus documentStatus) => _documentStatus = documentStatus;

        // реализация интерфейса
        // если включен флаг статуса, то выполнить действия для этого статуса
        // скорее всего тут нужно только выключать пройденный флаг, 
        // будут выполнять собственный handler для статуса
        public bool IsRequiredStatus(Document document) 
            => _documentStatus == (document.RequiredStatuses & _documentStatus);
        // выключить флаг
        // пример
        // включены флаги: 110
        // флаг текущего статуса: 010
        // 110 & ~(010) = 110 & 101 = 100
        public void FinishStatus(Document document) 
            => document.RequiredStatuses = document.RequiredStatuses & ~_documentStatus;
        public abstract void Service(Document document);
    }

    #region status_handler
    public class NoneStatus : StatusHandler
    {
        public NoneStatus() : base(DocumentStatus.None) { }
        public override void Service(Document document)
        {
            Console.WriteLine($"Status: {nameof(NoneStatus)}");
        }
    }

    public class DraftStatus : StatusHandler
    {
        public DraftStatus() : base(DocumentStatus.Draft) { }
        public override void Service(Document document)
        {
            Console.WriteLine($"Status: {nameof(DraftStatus)}");
        }
    }

    public class OnManagerApprovalStatus : StatusHandler
    {
        public OnManagerApprovalStatus() : base(DocumentStatus.OnManagerApproval) { }
        public override void Service(Document document)
        {
            Console.WriteLine($"Status: {nameof(OnManagerApprovalStatus)}");
        }
    }

    public class OnFinancialApprovalStatus : StatusHandler
    {
        public OnFinancialApprovalStatus() : base(DocumentStatus.OnFinancialApproval) { }
        public override void Service(Document document)
        {
            Console.WriteLine($"Status: {nameof(OnFinancialApprovalStatus)}");
        }
    }

    public class OnDirectorApprovalStatus : StatusHandler
    {
        public OnDirectorApprovalStatus() : base(DocumentStatus.OnDirectorApproval) { }
        public override void Service(Document document)
        {
            Console.WriteLine($"Status: {nameof(OnDirectorApprovalStatus)}");
        }
    }

    public class CompletedStatus : StatusHandler
    {
        public CompletedStatus() : base(DocumentStatus.Completed) { }
        public override void Service(Document document)
        {
            Console.WriteLine($"Status: {nameof(CompletedStatus)}");
        }
    }
    #endregion

    #region status_decorator
    public class DocumentStatusDecorator : IStatusHandler
    {
        private readonly StatusHandler StatusHandler;
        public DocumentStatusDecorator(StatusHandler statusHandler)
        {
            StatusHandler = statusHandler;
        }

        public void Service(Document document)
        {
            if (StatusHandler.IsRequiredStatus(document))
            {
                StatusHandler.Service(document);
                StatusHandler.FinishStatus(document);
            }
        }

        public bool IsRequiredStatus(Document document) => StatusHandler.IsRequiredStatus(document);
        public void FinishStatus(Document document) => StatusHandler.FinishStatus(document);
    }
    #endregion


    #region document
    public class Document
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
