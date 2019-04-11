using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStoreAssignment2.Models
{
    public interface IMockSuggestion
    {
        IQueryable<Suggestion> suggestions { get; }
        Suggestion Save(Suggestion suggestion);
        void Delete(Suggestion suggestion);
        void Dispose();
    }
}