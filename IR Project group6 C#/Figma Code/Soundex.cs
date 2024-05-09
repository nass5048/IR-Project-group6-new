using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Shapes;
using System;
using Uno.Extensions.Markup;
using Uno.Toolkit.UI;

namespace IR.Group.Project;

public partial class Inverted_Index : Page
{
	public Inverted_Index()
	{
		this
			.Background(Theme.Brushes.Background.Default)
			.Content
			(
				new ScrollViewer()
					.VerticalAlignment(VerticalAlignment.Stretch)
					.HorizontalAlignment(HorizontalAlignment.Stretch)
					.Content
					(
						new AutoLayout()
							.CounterAxisAlignment(AutoLayoutAlignment.Start)
							.Children
							(
								new AutoLayout()
									.CounterAxisAlignment(AutoLayoutAlignment.Start)
									.Padding(2,0)
									.Margin(289,1,0,0)
									.VerticalAlignment(VerticalAlignment.Top)
									.HorizontalAlignment(HorizontalAlignment.Left)
									.Width(391)
									.Height(46)
									.AutoLayout(isIndependentLayout: true)
									.Children
									(
										new AutoLayout()
											.Spacing(2)
											.PrimaryAxisAlignment(AutoLayoutAlignment.Center)
											.CounterAxisAlignment(AutoLayoutAlignment.Center)
											.Children
											(
												new TextBlock()
													.TextAlignment(TextAlignment.Center)
													.Text("Term Frequency")
													.Foreground(ThemeResource.Get<Brush>("Black")),
												new Rectangle()
													.RadiusX(1)
													.RadiusY(1)
													.Fill(ThemeResource.Get<Brush>("Black"))
													.Height(2)
													.AutoLayout(counterAlignment: AutoLayoutAlignment.Stretch)
											)
									),
								new AutoLayout()
									.CounterAxisAlignment(AutoLayoutAlignment.Start)
									.Padding(2,0)
									.Margin(680,1,0,0)
									.VerticalAlignment(VerticalAlignment.Top)
									.HorizontalAlignment(HorizontalAlignment.Left)
									.Width(183)
									.Height(46)
									.AutoLayout(isIndependentLayout: true)
									.Children
									(
										new AutoLayout()
											.Spacing(2)
											.PrimaryAxisAlignment(AutoLayoutAlignment.Center)
											.CounterAxisAlignment(AutoLayoutAlignment.Center)
											.Children
											(
												new TextBlock()
													.TextAlignment(TextAlignment.Center)
													.Text("Search")
													.Foreground(ThemeResource.Get<Brush>("Black")),
												new Rectangle()
													.RadiusX(1)
													.RadiusY(1)
													.Fill(ThemeResource.Get<Brush>("Black"))
													.Height(2)
													.AutoLayout(counterAlignment: AutoLayoutAlignment.Stretch)
											)
									),
								new AutoLayout()
									.CounterAxisAlignment(AutoLayoutAlignment.Start)
									.Padding(2,0)
									.Margin(863,1,0,0)
									.VerticalAlignment(VerticalAlignment.Top)
									.HorizontalAlignment(HorizontalAlignment.Left)
									.Width(349)
									.Height(46)
									.AutoLayout(isIndependentLayout: true)
									.Children
									(
										new AutoLayout()
											.Spacing(2)
											.PrimaryAxisAlignment(AutoLayoutAlignment.Center)
											.CounterAxisAlignment(AutoLayoutAlignment.Center)
											.Opacity(0.65)
											.Children
											(
												new TextBlock()
													.TextAlignment(TextAlignment.Center)
													.Text("Inverted Index")
													.Foreground(ThemeResource.Get<Brush>("Primary_Brush")),
												new Rectangle()
													.RadiusX(1)
													.RadiusY(1)
													.Fill(ThemeResource.Get<Brush>("Primary_Brush"))
													.Height(2)
													.AutoLayout(counterAlignment: AutoLayoutAlignment.Stretch)
											)
									),
								new AutoLayout()
									.CounterAxisAlignment(AutoLayoutAlignment.Start)
									.Margin(0,1,0,0)
									.VerticalAlignment(VerticalAlignment.Top)
									.HorizontalAlignment(HorizontalAlignment.Left)
									.Width(289)
									.Height(46)
									.AutoLayout(isIndependentLayout: true)
									.Children
									(
										new AutoLayout()
											.Spacing(2)
											.PrimaryAxisAlignment(AutoLayoutAlignment.Center)
											.CounterAxisAlignment(AutoLayoutAlignment.Center)
											.Padding(2,0)
											.Children
											(
												new TextBlock()
													.TextAlignment(TextAlignment.Center)
													.Text("Total Words ")
													.Foreground(ThemeResource.Get<Brush>("Black")),
												new Rectangle()
													.RadiusX(1)
													.RadiusY(1)
													.Fill(ThemeResource.Get<Brush>("Black"))
													.Height(2)
													.AutoLayout(counterAlignment: AutoLayoutAlignment.Stretch)
											)
									),
								new AutoLayout()
									.CounterAxisAlignment(AutoLayoutAlignment.Start)
									.Padding(2,0)
									.Margin(1212,1,0,0)
									.VerticalAlignment(VerticalAlignment.Top)
									.HorizontalAlignment(HorizontalAlignment.Left)
									.Width(225)
									.Height(46)
									.AutoLayout(isIndependentLayout: true)
									.Children
									(
										new AutoLayout()
											.Spacing(2)
											.PrimaryAxisAlignment(AutoLayoutAlignment.Center)
											.CounterAxisAlignment(AutoLayoutAlignment.Center)
											.Children
											(
												new TextBlock()
													.TextAlignment(TextAlignment.Center)
													.Text(" Soundex")
													.Foreground(ThemeResource.Get<Brush>("Black")),
												new Rectangle()
													.RadiusX(1)
													.RadiusY(1)
													.Fill(ThemeResource.Get<Brush>("Black"))
													.Height(2)
													.AutoLayout(counterAlignment: AutoLayoutAlignment.Stretch)
											)
									),
								new Rectangle()
									.Margin(0,61,0,0)
									.VerticalAlignment(VerticalAlignment.Top)
									.HorizontalAlignment(HorizontalAlignment.Left)
									.Width(663)
									.Height(1096)
									.AutoLayout(isIndependentLayout: true)
							)
					)
			);
	}
}
