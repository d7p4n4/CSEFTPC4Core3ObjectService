using CSEFTPC4Core3Objects.Ac4yObjects;
using CSEFTPC4Core3ObjectService.ObjectServices;
using System;

namespace CSEFTPC4Core3ObjectService
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Ac4yPersistentChildEFService.InsertResponse insertResponse =
                    new Ac4yPersistentChildEFService().Insert(new Ac4yPersistentChildEFService.InsertRequest()
                    {
                        Ac4yPersistentChild = new Ac4yPersistentChild()
                        {
                            name = "Stewie",
                            ages = 2
                        }
                    });
            }catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
