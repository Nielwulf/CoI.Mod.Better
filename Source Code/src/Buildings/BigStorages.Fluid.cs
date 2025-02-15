﻿using Mafi;
using Mafi.Base;
using Mafi.Core.Buildings.Storages;
using Mafi.Core.Entities.Static;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Factory;
using Mafi.Core.Mods;
using Mafi.Core.Products;
using Mafi.Core.Prototypes;
using Mafi.Localization;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace CoI.Mod.Better
{
    internal partial class BigStorages : IModData
    {

        #region Fluid Storages
        private void FluidStoragesT1(ProtoRegistrator registrator)
        {
            // Set proto ids
            StaticEntityProto.ID protoID = Ids.Buildings.StorageFluid;
            StaticEntityProto.ID protoNextTier = Ids.Buildings.StorageFluidT2;

            if (BetterMod.Config.OverrideVanillaStorages)
            {
                // Remove from Database
                registrator.PrototypesDb.RemoveOrThrow(protoID);
            }
            else
            {
                protoID = MyIDs.Buildings.StorageFluidT1;
                protoNextTier = MyIDs.Buildings.StorageFluidT2;
            }


            // Generate LocStr
            LocStr1 locStr = Loc.Str1("StorageSolidFormattedBase__desc", "Stores up to {0} units of a solid product.", "description for storage");


            // Add new to Database
            StorageProtoBuilder.State creator = registrator.StorageProtoBuilder.Start("Fluid storage", protoID)
                .Description(LocalizationManager.CreateAlreadyLocalizedStr(protoID.Value + "__desc", locStr.Format(capacity_fluid_T1.ToString()).Value))
                .SetCost(Costs.Buildings.StorageFluid)
                .SetNextTier(registrator.PrototypesDb.GetOrThrow<StorageProto>(protoNextTier))
                .SetCapacity(capacity_fluid_T1)
                .SetProductsFilter(ProductFilter)
                .SetLayout("   [4][4][4][4][4]   ", " @ >4A[4][4][4]X4> @ ", "   [4][4][4][4][4]   ", " @ >4B[4][4][4]Y4> @ ", "   [4][4][4][4][4]   ")
                .SetPrefabPath("Assets/Base/Buildings/Storages/GasT1.prefab")
                .SetFluidIndicatorGfxParams("Object397/liquid", new FluidIndicatorGfxParams(1f, 1.3f, 2f))
                .SetAsLockedOnInit();

            if (!BetterMod.Config.OverrideVanillaStorages) 
            {
                creator.SetCustomIconPath(registrator.PrototypesDb.GetOrThrow<StorageProto>(Ids.Buildings.StorageFluid).Graphics.IconPath);
            }

            creator = SetCategory(creator);
            SetTransferLimitByT(creator, 1).BuildAsFluidAndAdd();
            Debug.Log("BigStorages >> FluidStoragesT1 (override:" + BetterMod.Config.OverrideVanillaStorages + ") >> created!");
        }

        private void FluidStoragesT2(ProtoRegistrator registrator)
        {
            // Set proto ids
            StaticEntityProto.ID protoID = Ids.Buildings.StorageFluidT2;

            if (BetterMod.Config.OverrideVanillaStorages)
            {
                // Remove from Database
                registrator.PrototypesDb.RemoveOrThrow(protoID);
            }
            else
            {
                protoID = MyIDs.Buildings.StorageFluidT2;
            }

            // Generate LocStr
            LocStr1 locStr = Loc.Str1("StorageFluidFormattedBase__desc", "Stores up to {0} units of a liquid or gas product.", "description for storage");

            // Add new to Database
            var creator = registrator.StorageProtoBuilder.Start("Fluid storage II", protoID)
                .Description(LocalizationManager.CreateAlreadyLocalizedStr(protoID.Value + "__desc", locStr.Format(capacity_fluid_T2.ToString()).Value))
                .SetCost(Costs.Buildings.StorageFluidT2)
                .SetCapacity(capacity_fluid_T2)
                .SetProductsFilter(ProductFilter)
                .SetLayout("   [5][5][5][5][5]   ", " @ >5A[5][5][5]X5> @ ", "   [5][5][5][5][5]   ", " @ >5B[5][5][5]Y5> @ ", "   [5][5][5][5][5]   ")
                .SetPrefabPath("Assets/Base/Buildings/Storages/GasT2.prefab")
                .SetFluidIndicatorGfxParams("Object395/liquid001", new FluidIndicatorGfxParams(1f, 1.3f, 2f));

            if (!BetterMod.Config.OverrideVanillaStorages)
            {
                creator.SetCustomIconPath(registrator.PrototypesDb.GetOrThrow<StorageProto>(Ids.Buildings.StorageFluidT2).Graphics.IconPath);
            }
            creator = SetCategory(creator);
            SetTransferLimitByT(creator, 2).BuildAsFluidAndAdd();
            Debug.Log("BigStorages >> FluidStoragesT2 (override:" + BetterMod.Config.OverrideVanillaStorages + ") >> created!");
        }

        private void FluidStoragesT3(ProtoRegistrator registrator)
        {
            // Set proto ids
            StaticEntityProto.ID protoID = Ids.Buildings.StorageFluidT3;
            StaticEntityProto.ID protoNextTier = Ids.Buildings.StorageFluidT4;

            if (BetterMod.Config.OverrideVanillaStorages)
            {
                // Remove from Database
                registrator.PrototypesDb.RemoveOrThrow(protoID);
            }
            else
            {
                protoID = MyIDs.Buildings.StorageFluidT3;
                protoNextTier = MyIDs.Buildings.StorageFluidT4;
            }

            // Generate LocStr
            LocStr1 locStr = Loc.Str1("StorageFluidFormattedBase__desc", "Stores up to {0} units of a liquid or gas product.", "description for storage");

            // Add new to Database
            var creator = registrator.StorageProtoBuilder.Start("Fluid storage III", protoID)
                .Description(LocalizationManager.CreateAlreadyLocalizedStr(protoID.Value + "__desc", locStr.Format(capacity_fluid_T3.ToString()).Value))
                .SetCost(Costs.Buildings.StorageFluidT3)
                .SetNextTier(registrator.PrototypesDb.GetOrThrow<StorageProto>(protoNextTier))
                .SetCapacity(capacity_fluid_T3)
                .SetProductsFilter(ProductFilter)
                .SetLayout("      [6][6][6][6][6][6][6][6]      ", " @ >6A[6][6][6][6][6][6][6][6]X6> @ ", "   [6][6][6][6][6][6][6][6][6][6]   ", " @ >6B[6][6][6][6][6][6][6][6]Y6> @ ", "   [6][6][6][6][6][6][6][6][6][6]   ", "   [6][6][6][6][6][6][6][6][6][6]   ", " @ >6C[6][6][6][6][6][6][6][6]Z6> @ ", "   [6][6][6][6][6][6][6][6][6][6]   ", " @ >6D[6][6][6][6][6][6][6][6]W6> @ ", "      [6][6][6][6][6][6][6][6]      ")
                .SetPrefabPath("Assets/Base/Buildings/Storages/GasT3.prefab")
                .SetFluidIndicatorGfxParams("gas_1010_T1_seg2/liquid", new FluidIndicatorGfxParams(1f, 2.6f, 2f));

            if (!BetterMod.Config.OverrideVanillaStorages)
            {
                creator.SetCustomIconPath(registrator.PrototypesDb.GetOrThrow<StorageProto>(Ids.Buildings.StorageFluidT3).Graphics.IconPath);
            }
            creator = SetCategory(creator);
            SetTransferLimitByT(creator, 3).BuildAsFluidAndAdd();
            Debug.Log("BigStorages >> FluidStoragesT3 (override:" + BetterMod.Config.OverrideVanillaStorages + ") >> created!");
        }

        private void FluidStoragesT4(ProtoRegistrator registrator)
        {
            // Set proto ids
            StaticEntityProto.ID protoID = Ids.Buildings.StorageFluidT4;

            if (BetterMod.Config.OverrideVanillaStorages)
            {
                // Remove from Database
                registrator.PrototypesDb.RemoveOrThrow(protoID);
            }
            else
            {
                protoID = MyIDs.Buildings.StorageFluidT4;
            }

            // Generate LocStr
            LocStr1 locStr = Loc.Str1("StorageFluidFormattedBase__desc", "Stores up to {0} units of a liquid or gas product.", "description for storage");

            // Add new to Database
            var creator = registrator.StorageProtoBuilder.Start("Fluid storage IV", protoID)
                .Description(LocalizationManager.CreateAlreadyLocalizedStr(protoID.Value + "__desc", locStr.Format(capacity_fluid_T4.ToString()).Value))
                .SetCost(Costs.Buildings.StorageFluidT4)
                .SetCapacity(capacity_fluid_T4)
                .SetProductsFilter(ProductFilter)
                .SetLayout("      [9][9][9][9][9][9][9][9]      ", " @ >9A[9][9][9][9][9][9][9][9]X9> @ ", "   [9][9][9][9][9][9][9][9][9][9]   ", " @ >9B[9][9][9][9][9][9][9][9]Y9> @ ", "   [9][9][9][9][9][9][9][9][9][9]   ", "   [9][9][9][9][9][9][9][9][9][9]   ", " @ >9C[9][9][9][9][9][9][9][9]Z9> @ ", "   [9][9][9][9][9][9][9][9][9][9]   ", " @ >9D[9][9][9][9][9][9][9][9]W9> @ ", "      [9][9][9][9][9][9][9][9]      ")
                .SetPrefabPath("Assets/Base/Buildings/Storages/GasT4.prefab")
                .SetFluidIndicatorGfxParams("gas_1010_T2_seg3/liquid", new FluidIndicatorGfxParams(1f, 2.6f, 2f));

            if (!BetterMod.Config.OverrideVanillaStorages)
            {
                creator.SetCustomIconPath(registrator.PrototypesDb.GetOrThrow<StorageProto>(Ids.Buildings.StorageFluidT4).Graphics.IconPath);
            }
            creator = SetCategory(creator);
            SetTransferLimitByT(creator, 4).BuildAsFluidAndAdd();
            Debug.Log("BigStorages >> FluidStoragesT4 (override:" + BetterMod.Config.OverrideVanillaStorages + ") >> created!");
        }

        #endregion

    }
}