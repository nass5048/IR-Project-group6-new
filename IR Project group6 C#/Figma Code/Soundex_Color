using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Uno.Extensions.Markup;
using Windows.UI;

namespace IR.Group.Project;

public partial class ColorPaletteOverride : ResourceDictionary
{
	public ColorPaletteOverride()
	{
		this
			.Build
			(
				r => r
					.Add<Color>("Primary_Color", Color.FromArgb(0xFF, 0x00, 0x55, 0xD6))
					.Add<SolidColorBrush>("Primary_Brush", 	new SolidColorBrush()
		.Color(ThemeResource.Get<Color>("Primary_Color")))
			);
	}
}
