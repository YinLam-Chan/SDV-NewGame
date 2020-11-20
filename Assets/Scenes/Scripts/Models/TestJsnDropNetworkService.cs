using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TestJsnDropNetworkService : MonoBehaviour
{
    public void jsnReceiverDel(JsnReceiver pReceived)
    {
        Debug.Log(pReceived.JsnMsg + " ..." + pReceived.Msg);
        // To do: parse and produce an appropriate response
    }

    public void jsnListReceiverDel(List<Person> pReceivedList)
    {
        Debug.Log("Received items " + pReceivedList.Count());
        foreach (Person lcReceived in pReceivedList)
        {
            Debug.Log("Received {" + lcReceived.Name + "," + lcReceived.Password + "," + lcReceived.Score.ToString()+"}");
        }// for

        // To do: produce an appropriate response
    }
    // Start is called before the first frame update
    void Start()
    {
        #region Test jsn drop
        //JSONDropService jsDrop = new JSONDropService { Token = "0031b110-baf3-4988-86c3-122c2a770b46" };

        // Create table person
        /*jsDrop.Create<Person, JsnReceiver>(new Person
        {
            Name = "UUUUUUUUUUUUUUUUUUUUUUUUUUU",
            Score = 0,
            Password = "***************************"
        }, jsnReceiverDel);
        
        // Store people records
        jsDrop.Store<Person,JsnReceiver> (new List<Person>
        {
            new Person{Name = "Jack",Score = 100,Password ="test"},
            new Person{Name = "Jonny",Score = 200,Password ="test1"},
            new Person{Name = "Jill",Score = 300,Password ="test2"}
         }, jsnReceiverDel);
        */
        // Retreive all people records
        //GameModel.jsDrop.All<Person, JsnReceiver>(jsnListReceiverDel, jsnReceiverDel);
        
        /*jsDrop.Select<Person,JsnReceiver>("Score > 200",jsnListReceiverDel, jsnReceiverDel);
        
        jsDrop.Delete<Person, JsnReceiver>("Name = 'Jonny'", jsnReceiverDel);
        */
        //GameModel.jsDrop.Drop<Person, JsnReceiver>(jsnReceiverDel);
        
        #endregion

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

