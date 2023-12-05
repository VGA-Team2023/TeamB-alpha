namespace TeamB_TD
{
    public interface IWeaponType
    {
        WeaponType WeaponType {  get; }
    }

    public enum WeaponType
    {
        None = 0,
        Range = 2,
        Melee = 3,
    }
}



