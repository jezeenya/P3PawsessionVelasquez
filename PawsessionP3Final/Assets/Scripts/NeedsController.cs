using UnityEngine;
using System;

public class NeedsController : MonoBehaviour
{
    public int food, happiness, energy;
    public int foodTickRate, happinessTickRate, energyTickRate;
    public DateTime lastTimeFed, lastTimeHappy, lastTimeGainedEnergy;
    public PetManager petManager;




    private void Awake()
    {
        if (food == 0 && happiness == 0 && energy == 0)
        {
            Initialize(100, 100, 100, 10, 10, 10);
        }
    }

    public void Initialize(int food, int happiness, int energy, int foodTickRate, int happinessTickRate, int energyTickRate)
    {
        this.lastTimeFed = DateTime.Now;
        this.lastTimeHappy = DateTime.Now;
        this.lastTimeGainedEnergy = DateTime.Now;

        this.food = food;
        this.happiness = happiness;
        this.energy = energy;
        this.foodTickRate = foodTickRate;
        this.happinessTickRate = happinessTickRate;
        this.energyTickRate = energyTickRate;

        PetUIController.instance.UpdateImages(food, happiness, energy, foodTickRate, happinessTickRate, energyTickRate);
    }

    public void Initialize(int food, int happiness, int energy, int foodTickRate, int happinessTickRate, int energyTickRate
        , DateTime lastTimeFed, DateTime lastTimeHappy, DateTime lastTimeGainedEnergy)
    {
        this.lastTimeFed = lastTimeFed;
        this.lastTimeHappy = lastTimeHappy;
        this.lastTimeGainedEnergy = lastTimeGainedEnergy;

        this.food = food;
        this.happiness = happiness;
        this.energy = energy;
        this.foodTickRate = foodTickRate;
        this.happinessTickRate = happinessTickRate;
        this.energyTickRate = energyTickRate;
        PetUIController.instance.UpdateImages(food, happiness, energy, foodTickRate, happinessTickRate, energyTickRate);

    }


    private void Update()
    {
        if(TimingManager.gameHourTimer < 0)
        {
            ChangeFood(-foodTickRate);
            ChangeHappiness(-happinessTickRate);
            ChangeEnergy(-energyTickRate);
            PetUIController.instance.UpdateImages(food, happiness, energy, foodTickRate, happinessTickRate, energyTickRate);
        }
    }

    public void ChangeFood(int amount)
    {
        food += amount;
        if(amount > 0)
        {
            this.lastTimeFed = DateTime.Now;

        }
        if (food < 0)
        {
            petManager.Die();
            
        }
        else if (food > 100) food = 100;
    }

    public void ChangeHappiness(int amount)
    {
        happiness += amount;
        if(amount < 0)
        {
            this.lastTimeHappy = DateTime.Now;

        }
        if (happiness < 0)
        {
            petManager.Die();
        }
        else if (happiness > 100) happiness = 100;
    }

    public void ChangeEnergy(int amount)
    {
        energy += amount;
        if(amount < 0 )
        {
            this.lastTimeGainedEnergy = DateTime.Now;

        }
        if (energy < 0)
        {
            petManager.Die();
        }
        else if (energy > 100) energy = 100;
    }

    public void FeedButton()
    {
        ChangeFood(10);
        PetUIController.instance.UpdateImages(food, happiness, energy);
        SaveNeeds();
    }

    public void PlayButton()
    {
        ChangeHappiness(2);
        PetUIController.instance.UpdateImages(food, happiness, energy);
        SaveNeeds();
    }

    public void SleepButton()
    {
        ChangeEnergy(5);
        PetUIController.instance.UpdateImages(food, happiness, energy);
        SaveNeeds();
    }

    public void LoadNeeds()
    {
        if (PlayerPrefs.HasKey("Food"))
        {
            food = PlayerPrefs.GetInt("Food");
            happiness = PlayerPrefs.GetInt("Happiness");
            energy = PlayerPrefs.GetInt("Energy");

            long lastFedBinary = Convert.ToInt64(PlayerPrefs.GetString("LastFed"));
            long lastHappyBinary = Convert.ToInt64(PlayerPrefs.GetString("LastHappy"));
            long lastEnergyBinary = Convert.ToInt64(PlayerPrefs.GetString("LastEnergy"));

            lastTimeFed = DateTime.FromBinary(lastFedBinary);
            lastTimeHappy = DateTime.FromBinary(lastHappyBinary);
            lastTimeGainedEnergy = DateTime.FromBinary(lastEnergyBinary);

            PetUIController.instance.UpdateImages(food, happiness, energy);
        }
    }

    public void SaveNeeds()
    {
        PlayerPrefs.SetInt("Food", food);
        PlayerPrefs.SetInt("Happiness", happiness);
        PlayerPrefs.SetInt("Energy", energy);

        PlayerPrefs.SetString("LastFed", lastTimeFed.ToBinary().ToString());
        PlayerPrefs.SetString("LastHappy", lastTimeHappy.ToBinary().ToString());
        PlayerPrefs.SetString("LastEnergy", lastTimeGainedEnergy.ToBinary().ToString());

        PlayerPrefs.Save();
    }

    
    
}
