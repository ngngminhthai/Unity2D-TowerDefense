using UnityEngine.SceneManagement;

public class HeadQuarter : Unit
{


    private void Start()
    {
        BaseHitPoints = 500f;
        HitPoints = 500f;
        healthBar.SetMaxHealth(HitPoints);
    }

    public HeadQuarter(int level) : base(level)
    {
        Level = level;
    }


    public override void TakeDamage(float amount)
    {
        //Debug.Log("towertake");
        HitPoints -= amount;
        healthBar.SetHealth(HitPoints);
        if (HitPoints <= 0)
        {
            Die();
            SceneManager.LoadScene("GameOver");
        }
    }


    protected override void Die()
    {
        // Destroy the game object
        Destroy(gameObject);

    }

    //public virtual void LevelUp()
    //{
    //    Level++;
    //}
}