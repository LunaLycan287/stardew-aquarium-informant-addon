using Moonwolf.StardewAquariumInformant.ThirdParty;
using StardewModdingAPI;

namespace Moonwolf.StardewAquariumInformant
{
    public class StardewAquariumInformantMod : Mod
    {
        public override void Entry(IModHelper helper)
        {
            Helper.Events.GameLoop.GameLaunched += (sender, args) => {
                IInformant? informant = Helper.ModRegistry.GetApi<IInformant>("Slothsoft.Informant");
                if (informant is null)
                    return;
                
                AquariumDecorator decorator = new AquariumDecorator(helper);
                informant.AddItemDecorator(decorator.Id, decorator.GetDisplayName, decorator.GetDescription, decorator.GetDecorator);
            };
        }
    }
}