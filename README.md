# examples-dotnet-win

---

## The way to the present

```shell
git clone https://github.com/suzu-devworks/examples-dotnet-win.git
cd examples-dotnet-win

dotnet new sln -o .

## Examples.WinForms
dotnet new winforms -o src/Examples.WinForms
dotnet sln add src/Examples.WinForms
cd src/Examples.WinForms
cd ..


## Examples.WinForms.Controls
dotnet new winformscontrollib -o src/Examples.WinForms.Controls
dotnet sln add src/Examples.WinForms.Controls
dotnet add src/Examples.WinForms reference src/Examples.WinForms.Controls
cd src/ExamExamples.WinForms.Controlss
cd ..


## Examples.WpfPrism
dotnet new wpf -o src/Examples.WpfPrism
dotnet sln add src/Examples.WpfPrism
cd src/Examples.WpfPrism
dotnet add package Prism.dryioc
cd ..


```

## Wpf Prism 8.0

1. Edit `App.xaml` and `App.xaml.cs`
2. Edit `prism:ViewModelLocator.AutoWireViewModel="True"` in Xaml

