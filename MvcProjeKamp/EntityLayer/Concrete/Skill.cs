public class Skill
{
    public int SkillId { get; set; }
    public string SkillName { get; set; }
    public string Description { get; set; }
    public int SkillValue { get; set; } 

    public void IncreaseSkillValue(int increaseAmount)
    {
        SkillValue += increaseAmount;
        if (SkillValue > 100) SkillValue = 100;
    }

    public void DecreaseSkillValue(int decreaseAmount)
    {
        SkillValue -= decreaseAmount;
        if (SkillValue < 0) SkillValue = 0;
    }
}
