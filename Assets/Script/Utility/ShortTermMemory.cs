using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortTermMemory : MonoBehaviour {

    public static ShortTermMemory memory = null;

    const int __MAXMARBLES = 8,
              __MINMARBLES = 4;

    const int __MAXCOLORS = 8,
              __MINCOLORS = 3;

    int numberOfMarbles;
    int numberOfColors;

    bool littleSpace = false;

    // Use this for initialization
    void Awake() {
        if (memory == null) {
            DontDestroyOnLoad(gameObject);
            memory = this;
        }
        else if (memory != this) {
            DestroyImmediate(gameObject);
        }
    }

    /**
     * to change the number of the marbles
     * accept 1 and -1
     * it's also readable
     */
    public int ChangeMarblesNumber(int i) {
        if(i == +1) {
            if (numberOfMarbles < __MAXMARBLES) {
                numberOfMarbles++;
            }else if (numberOfMarbles >= __MAXMARBLES) {
                numberOfMarbles = __MINMARBLES;
            }
        }else if (i == -1) {
            if (numberOfMarbles > __MINMARBLES) {
                numberOfMarbles--;
            }
            else if (numberOfMarbles <= __MINMARBLES) {
                numberOfMarbles = __MAXMARBLES;
            }
        }
        return numberOfMarbles;
    }

    /**
     * to change the number of the colors in the palette
     * accept 1 and -1
     * it's also readable
     */
    public int ChangeColorsNumber(int i) {
        if (i == +1) {
            if (numberOfColors < __MAXCOLORS) {
                numberOfColors++;
            }
            else if (numberOfColors >= __MAXCOLORS) {
                numberOfColors = __MINCOLORS;
            }
        }
        else if (i == -1) {
            if (numberOfColors > __MINCOLORS) {
                numberOfColors--;
            }
            else if (numberOfColors <= __MINCOLORS) {
                numberOfColors = __MAXCOLORS;
            }
        }
        return numberOfColors;
    }

    public void SetNumberOfMarbles(int i) {
        if (i >= __MINMARBLES && i <= __MAXMARBLES) {
            numberOfMarbles = i;
        }
    }

    public void SetNumberOfColors(int i) {
        if (i >= __MINCOLORS && i <= __MAXCOLORS) {
            numberOfColors = i;
        }
    }


    /**
     * is needed some space between tiles?
     */
    public bool GetSpacing () {
        return littleSpace;
    }

    public void SetSpacing(bool b) {
        littleSpace = b;
    }

    /**
     * flip the spacing from tile to tile condition and return the new value if needed;
     */
    public bool FlipSpacing () {
        littleSpace = !littleSpace;
        return littleSpace;
    }
    
}
