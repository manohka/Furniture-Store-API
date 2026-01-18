using FurnitureStoreAPI.Patterns.BehavioralPattterns.RefactoringGuru.Observer.Interface;

namespace FurnitureStoreAPI.Patterns.BehavioralPattterns.RefactoringGuru.Observer.ConcreteObservers
{
    public class ConcreteObserverA : IObserver
    {
        public void Update(ISubject subject)
        {
            if ((subject as Subject).State < 3)
            {
                Console.WriteLine("ConcreteObserverA: Reacted to the event.");
            }
        }

    }
}
