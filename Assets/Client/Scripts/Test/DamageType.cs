using System;

[Flags]
public enum DamageType
{
    None = 0,
    Default = 1,

    Slashing = 2,
    Crushing = 4,
    Piercing = 8,
    Melee = Slashing | Crushing | Piercing,

    Stitching = 16,
    Tearing = 32,
    Ranged = Stitching | Tearing,

    Fire = 64,
    Ice = 128,
    Poison = 256,
    Magic = 512,
    Elemental = Fire | Ice | Poison
}