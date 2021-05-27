using System;
using System.Collections.Generic;

namespace ResponsibilityChain
{
    class Program
    {
        static void Main()
        {
            var draftService = new DocumentStatusDecorator(new DraftStatus());
            var onManagerApprovalService = new DocumentStatusDecorator(new OnManagerApprovalStatus());
            var onFinApprovalService = new DocumentStatusDecorator(new OnFinancialApprovalStatus());
            var onDicrectorApprovalService = new DocumentStatusDecorator(new OnDirectorApprovalStatus());
            var onCompletedService = new DocumentStatusDecorator(new CompletedStatus());

            var documents = new List<Document>()
            {
                new Document(
                    "1",
                    DocumentStatus.Draft |
                    DocumentStatus.OnManagerApproval |
                    DocumentStatus.OnFinancialApproval |
                    DocumentStatus.OnDirectorApproval
                    ),

                new Document(
                    "2",
                    DocumentStatus.OnFinancialApproval
                    ),

                new Document(
                    "3",
                    DocumentStatus.OnManagerApproval |
                    DocumentStatus.OnDirectorApproval
                    )
            };

            foreach (var document in documents)
            {
                Console.WriteLine($"Document name: {document.DocumentName}");
                draftService.Invoke(document);
                onManagerApprovalService.Invoke(document);
                onFinApprovalService.Invoke(document);
                onDicrectorApprovalService.Invoke(document);
                onCompletedService.Invoke(document);
            }
        }
    }
}
