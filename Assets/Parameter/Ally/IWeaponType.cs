namespace TeamB_TD
{
    public interface IWeaponType
    {
        WeaponType WeaponType {  get; }
    }

    public enum WeaponType
    {
        None,
        Melee,
        Range
    }
}



