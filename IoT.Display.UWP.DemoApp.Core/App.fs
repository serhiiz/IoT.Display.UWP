namespace IoT.Display.UWP.DemoApp.Core

open IoT.Display
open IoT.Display.Graphics
open IoT.Display.Primitives
open IoT.Display.Layout
open IoT.Display.Devices
open IoT.Display.Devices.SSD1306

module App =
    let private init (display:ISSD1306) = 
        [
            setChargePumpOn 
            flipVertically 
            flipHorizontally 
        ] 
        |> List.iter display.SendCommand

        dock [][] |> renderToDisplay display
        turnOn |> display.SendCommand

    let run (display:ISSD1306) =
        init display
        
        DeactivateScroll |> display.SendCommand

        let margin = Margin (thicknessSame 2)
        
        dock [] [
            dock [Dock Dock.Top] [
                text [Dock Dock.Left; margin] "TL"
                text [Dock Dock.Right; margin] "TR"
            ]
            dock [Dock Dock.Bottom] [
                text [Dock Dock.Left; margin] "BL"
                text [Dock Dock.Right; margin] "BR"
            ]
            text [Dock Dock.Fill; HorizontalAlignment HorizontalAlignment.Center; VerticalAlignment VerticalAlignment.Center] "Welcome!"
            
        ]
        |> renderToDisplay display

        let hConfig = {
            Direction = ScrollDirection.Right; 
            StartPage = Page0; 
            EndPage = Page1; 
            Interval = ScrollInterval.Frames64
        }

        let vConfig = {
            Offset = 2uy; 
            StartRow = 24uy; 
            Height = 16uy;
        }

        SetupScroll (hConfig, Some vConfig) |> display.SendCommand
        ActivateScroll |> display.SendCommand
