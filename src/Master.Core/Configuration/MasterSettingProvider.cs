using Abp.Configuration;
using Abp.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Master.Configuration
{
    public static class SettingNames
    {
        public const string MenuSetting = "Menu";
        public const string CodeSetting = "Code";
        public const string SoftTitle = "App.SoftTitle";
    }
    public class MasterSettingProvider : SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            //var interGroup = new SettingDefinitionGroup("InterSetting", L("内部设置"));
            //group设为null则不在设置页面中出现
            var menuSettingDefinition = new SettingDefinition(SettingNames.MenuSetting, "", L("菜单"), group: null, scopes: SettingScopes.Tenant | SettingScopes.User);


            var group = new SettingDefinitionGroup("Core", L("基本设置"));
            return new SettingDefinition[]
            {
                menuSettingDefinition,
                new SettingDefinition(SettingNames.SoftTitle, "Sartorius ",L("系统标题"),group, scopes: SettingScopes.Application , isVisibleToClients: true),
                new SettingDefinition(SettingNames.CodeSetting, "Sartorius ",L("识别码"),group, scopes: SettingScopes.Application , isVisibleToClients: true),

            };
        }

        private static LocalizableString L(string name)
        {
            return new LocalizableString(name, MasterConsts.LocalizationSourceName);
        }
    }
}
