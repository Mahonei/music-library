//===================================================================================
// Microsoft Developer & Platform Evangelism
//=================================================================================== 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//===================================================================================
// Copyright (c) Microsoft Corporation.  All Rights Reserved.
// This code is released under the terms of the MS-LPL license, 
// http://microsoftnlayerapp.codeplex.com/license
//===================================================================================

namespace MusicManager.Infrastructure.Crosscutting.NetFramework.Adapter
{
    using System;
    using System.Linq;
    using AutoMapper;
    using MusicManager.Infrastructure.Crosscutting.Adapter;
    using System.Collections.Generic;

    public class AutomapperTypeAdapterFactory
        :ITypeAdapterFactory
    {
        #region Constructor

        /// <summary>
        /// Create a new Automapper type adapter factory
        /// </summary>
        public AutomapperTypeAdapterFactory()
        {
            ////scan all assemblies finding Automapper Profile
            //var profiles = AppDomain.CurrentDomain
            //                        .GetAssemblies()
            //                        .SelectMany(a => a.GetTypes())
            //                        .Where(t => t.BaseType == typeof(Profile));

            //Mapper.Initialize(cfg =>
            //{
            //    foreach (var item in profiles)
            //    {
            //        if (item.FullName != "AutoMapper.SelfProfiler`2")
            //            cfg.AddProfile(Activator.CreateInstance(item) as Profile);
            //    } 
            //});
            Register();
        }

        #endregion

        #region ITypeAdapterFactory Members

        public ITypeAdapter Create()
        {
            return new AutomapperTypeAdapter();
        }

        #endregion

        private static Func<Type, bool> _validProfilesExpression = t => typeof(Profile).IsAssignableFrom(t) && t.GetConstructor(Type.EmptyTypes) != null;

        public static void Register()
        {
            // Apply handler for assembly load to register profiles
            // available on the new loaded assembly
            AppDomain.CurrentDomain.AssemblyLoad += CurrentDomainAssemblyLoad;

            var profiles = AppDomain.CurrentDomain
                                  .GetAssemblies()
                                    .SelectMany(a => a.GetTypes().Where(_validProfilesExpression)
                                    .Select(Activator.CreateInstance).Cast<Profile>()).ToList();
            Register(profiles);
        }

        private static void Register(List<Profile> profiles)
        {
            profiles.ForEach(Mapper.AddProfile);
        }

        private static void CurrentDomainAssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {
            if (args.LoadedAssembly.GetTypes().Any(_validProfilesExpression))
            {
                var profiles = args.LoadedAssembly.GetTypes().Where(_validProfilesExpression).Select(Activator.CreateInstance).Cast<Profile>().ToList();
                Register(profiles);
            }
        }
    }
    
}
