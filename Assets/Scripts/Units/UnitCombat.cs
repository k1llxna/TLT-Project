using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCombat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region combat
    protected IEnumerator Seek(float timer_)
    {
        yield return new WaitForSeconds(timer_);
    }

    protected IEnumerator Attack(float timer_)
    {
        yield return new WaitForSeconds(timer_);
    }

    //temporarily add stats
    protected IEnumerator RecieveBuffs(float timer_)
    {
        yield return new WaitForSeconds(timer_);
    }

    protected IEnumerator RecieveDebuffs(float timer_)
    {
        yield return new WaitForSeconds(timer_);
    }

    //add stats
    protected void ApplyItem()
    {

    }

    protected void RemoveItem()
    {

    }

    protected virtual void UseAbility()
    {

    }

    protected virtual void ApplyTrait(string trait, int tier)
    {

    }
    #endregion
}
