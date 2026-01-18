using System.Runtime.InteropServices.JavaScript;

namespace FurnitureStoreAPI.Patterns.BehavioralPattterns.RefactoringGuru.Observer.Interface
{
    public interface IObserver
    {
        // Receive update from subject
        void Update(ISubject subject);
    }
}
