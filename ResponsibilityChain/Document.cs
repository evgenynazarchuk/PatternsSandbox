﻿using System;

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
        protected DocumentStatus _documentStatus { get; set; }

        public StatusHandler(DocumentStatus documentStatus) => _documentStatus = documentStatus;

        // реализация интерфейса
        // если включен флаг статуса, то выполнить действия для этого статуса
        // скорее всего тут нужно только выключать пройденный флаг, 
        // будут выполнять собственный handler для статуса
        public bool IsRequiredStatus(IDocumentRequiredStatus document)
            => _documentStatus == (document.RequiredStatuses & _documentStatus);

        // выключить флаг
        // пример
        // включены флаги: 110
        // флаг текущего статуса: 010
        // 110 & ~(010) = 110 & 101 = 100
        public void FinishStatus(IDocumentRequiredStatus document) 
            => document.RequiredStatuses = document.RequiredStatuses & ~_documentStatus;

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
    public class NoneStatus : StatusHandler
    {
        public NoneStatus() : base(DocumentStatus.None) { }
        public override void Invoke(Document document)
        {
            Console.WriteLine($"Status: {nameof(NoneStatus)}");
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