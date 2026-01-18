using FurnitureStoreAPI.Patterns.BehavioralPattterns.RefactoringGuru.Observer.Interface;

namespace FurnitureStoreAPI.Patterns.BehavioralPattterns.RefactoringGuru.Observer.ConcreteObservers
{
    public class ConcreteObserverB : IObserver
    {
        public void Update(ISubject subject)
        {
            if ((subject as Subject).State == 0 || (subject as Subject).State >= 2)
            {
                Console.WriteLine("ConcreteObserverB: Reacted to the event.");
            }
        }
    }
}
