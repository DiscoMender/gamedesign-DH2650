using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // reference the moles
    [SerializeField] private List<Mushroom> moles;

    // a hash set of moles
    private HashSet<Mushroom> currentMoles = new HashSet<Mushroom>();
    private bool playing = false;

    public void Start()
    {
        // Hide all the visible moles
        for (int i = 0; i < moles.Count; i++)
        {
            moles[i].Hide();
            moles[i].SetIndex(i);
        }

        // Remove any old game state
        currentMoles.Clear();
        playing = true;

    }


    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            // check if we need to start any more moles
            if (currentMoles.Count < 2)
            {
                int index = Random.Range(0, moles.Count);
                if (!currentMoles.Contains(moles[index]))
                {
                    currentMoles.Add(moles[index]);
                    moles[index].Activate(2);
                    Debug.Log("Activate!");
                }
            }
        }
    }

    public void AddScore(int moleIndex)
    {
        // if we hit a mole 
        currentMoles.Remove(moles[moleIndex]);
    }

    public void Missed(int moleIndex)
    {
        // if we miss a mole
        currentMoles.Remove(moles[moleIndex]);
        PlayerStats.LoseMinigame("Whack_A_Mole");
    }
}
