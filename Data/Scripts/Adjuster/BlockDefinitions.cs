﻿using System.Collections.Generic;
using static ModAdjuster.DefinitionStructure;
using static ModAdjuster.DefinitionStructure.BlockDef;
using static ModAdjuster.DefinitionStructure.BlockDef.BlockAction.BlockMod;

namespace ModAdjuster
{
    public class BlockDefinitions
    {
        public string AdminComponent = "Component/ExampleComponent"; // Component to insert into disabled blocks to prevent building from projection
        public List<string> DisabledBlocks = new List<string>() // List of blocks to disable
        {
            "CubeBlock/ExampleArmorBlock",
            "OxygenFarm/ExampleOxygenFarm",
        };

        public List<BlockDef> Definitions = new List<BlockDef>()
        {
            // List of blocks to modify. Can be as many or few as desired
            new BlockDef()
            {
                BlockName = "WindTurbine/ExampleWindTurbine", // Name of the block to modify. Format is "MyObjectBuilder_Type/Subtype" in the same format as BlockVariantGroups
                BlockActions = new[] // List of modifications to make. Can be as many or few as desired
                {
                    // The following modifications can be used on any type of block
                    new BlockAction
                    {
                        Action = DisableBlockDefinition // Block will still exist in world and can be built from projections unfortunately
                    },
                    new BlockAction
                    {
                        Action = ChangeBlockName, // Change Display Name of the block
                        NewText = "New Block Name"
                    },
                    new BlockAction
                    {
                        Action = ChangeBlockDescription, // Change the Description of the block
                        NewText = "New Block Description"
                    },
                    new BlockAction
                    {
                        Action = ChangeBlockPublicity // Sets <Public> to the opposite of its setting in sbc
                    },
                    new BlockAction
                    {
                        Action = ChangeBlockGuiVisibility // Sets <GuiVisible> to the opposite of its setting in sbc
                    },
                    new BlockAction
                    {
                        Action = ChangePCU, // Sets block PCU
                        Value = 100
                    },
                    new BlockAction
                    {
                        Action = ChangeBuildTime, // Sets <BuildTimeSeconds>
                        Value = 45
                    },
                    new BlockAction
                    {
                        Action = ChangeDeformationRatio, // Controls damage taken from collisions and explosions
                        Value = 0.3f
                    },
                    new BlockAction
                    {
                        Action = ChangeResistance, // <GeneralDamageMultiplier>
                        Value = 0.5f
                    },
                    new BlockAction
                    {
                        Action = InsertComponent, // Inserts the given number of the given component at the given index of a block's component list
                        Component = "Component/Superconductor",
                        Index = 4,
                        Count = 20
                    },
                    new BlockAction
                    {
                        Action = ReplaceComponent, // Replaces the component at the given index with a new component
                        Component = "Component/Construction",
                        Index = 1,
                        Count = 32 // This field is optional. If not specified or set to 0, the component count will stay the same
                    },
                    new BlockAction
                    {
                        Action = ChangeComponentCount, // Changes the required number of the component at the given index
                        Index = 6,
                        Count = 100
                    },
                    new BlockAction
                    {
                        Action = ChangeComponentDeconstructId, // Sets what the component at the given index grinds down into.
                        Component = "Ore/Scrap",
                        Index = 5
                    },
                    new BlockAction
                    {
                        Action = ChangeCriticalComponentIndex, // Sets the critical component which must be welded up for the block to function
                        Index = 7
                    },
                }
            },

            new BlockDef()
            {
                BlockName = "HydrogenEngine/ExampleHydrogenEngine",
                BlockActions = new[]
                {
                    // These modifications are specific to power production blocks
                    new BlockAction
                    {
                        Action = ChangeFuelMultiplier, // Sets <FuelProductionToCapacityMultiplier> for Hydrogen Engines
                        Value = 0.05f
                    },
                    new BlockAction
                    {
                        Action = ChangeMaxPowerOutput, // Sets <MaxPowerOutput> for any reactor, hydrogen engine, solar panel, wind turbine, or battery
                        Value = 1.5f
                    },
                }
            },


            new BlockDef()
            {
                BlockName = "UpgradeModule/ExampleUpgradeModule",
                BlockActions = new[]
                {
                    // This modification is specific to upgrade modules
                    new BlockAction
                    {
                        Action = ChangeUpgradeModifier, // Sets the modifier for an upgrade module's upgrade
                        Value = 0.8f
                    }
                }
            },


            new BlockDef()
            {
                BlockName = "RadioAntenna/ExampleRadioAntenna",
                BlockActions = new[]
                {
                    // This modification is specific to beacons and antennae
                    new BlockAction
                    {
                        Action = ChangeBroadcastRadius,
                        Value = 10000f
                    }
                }
            },


            new BlockDef()
            {
                BlockName = "LaserAntenna/ExampleLaserAntenna",
                BlockActions = new[]
                {
                    // This modification is specific to laser antennae
                    new BlockAction
                    {
                        Action = ChangeLaserMaxRange,
                        Value = 10000f
                    }
                }
            },

            new BlockDef()
            {
                BlockName = "Drill/ExampleDrill",
                BlockActions = new[]
                {
                    // These modifications are specific to ship tools
                    new BlockAction
                    {
                        Action = ChangeSensorRadius, // Set the effect radius of any ship tool (welder, grinder, drill)
                        Value = 7.2f
                    },
                    new BlockAction
                    {
                        Action = ChangeCutOutRadius, // Set the mining radius of a Ship Drill
                        Value = 7.5f
                    }
                }
            },


            new BlockDef()
            {
                BlockName = "Thrust/ExampleThruster",
                BlockActions = new[]
                {
                    // These modifications are specific to thrusters
                    new BlockAction
                    {
                        Action = ChangeThrustForce,
                        Value = 10000f
                    },
                    new BlockAction
                    {
                        Action = ChangeThrustPowerConsumption,
                        Value = 0.1f
                    },
                    new BlockAction
                    {
                        Action = ChangeThrustFuelId,
                        Component = "GasProperties/Hydrogen"
                    },
                    new BlockAction
                    {
                        Action = ChangeThrustFuelEfficiency,
                        Value = 5f
                    },
                }
            },

            new BlockDef()
            {
                BlockName = "OxygenGenerator/ExampleOxygenGenerator",
                BlockActions = new[]
                {
                    new BlockAction
                    {
                        Action = ChangeOperationalPowerConsumption, // Set the working power consumption of any production block (assembler, refinery, gas generator, tank)
                        Value = 1.5f
                    },
                    new BlockAction
                    {
                        Action = ChangeIcePerSecond, // Set the ice consumption rate of a gas generator
                        Value = 7.5f
                    },
                    new BlockAction
                    {
                        Action = ChangeIceToGasRatio, // Set the ice to gas ratio of a gas generator for the specified gas
                        NewText = "Oxygen", // SubtypeId of the gas to change the ratio for
                        Value = 12.5f
                    }
                }
            },
            
            new BlockDef()
            {
                BlockName = "OxygenTank/ExampleOxygenTank",
                BlockActions = new[]
                {
                    new BlockAction
                    {
                        Action = ChangeTankCapacity, // Set the Tank Capacity and also adjust the explosion to match the new capacity
                        Value = 3000000f
                    }
                }
            },
        };

    }
}
