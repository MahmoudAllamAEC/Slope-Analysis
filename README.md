# Slope Analysis — Revit Add-In

A Revit add-in that analyzes the slope of selected floor elements and visually paints their faces based on whether the slope falls within a user-defined range.

---

## Overview

This tool allows structural or architectural teams to quickly identify floor surfaces that meet or fall outside a target slope tolerance. Faces are color-coded green (in range) or red (out of range) directly in the Revit 3D view.

---

## Features

- **Floor Selection** — Pick one or more floor elements directly in the Revit viewport.
- **Slope Range Input** — Define a minimum and maximum slope percentage to evaluate.
- **Face Painting** — Automatically paints each floor face green (within range) or red (outside range).
- **Reset** — Removes all applied paint and restores the original appearance.
- **Modern UI** — Built with MetroFramework for a clean, flat Windows Forms interface.

---

## Architecture

The add-in follows an **MVVM pattern** with Revit's **External Event** mechanism to safely interact with the Revit document from a modeless form.

```
├── Revit Entry
│   ├── ExtApp.cs                        # Registers the ribbon tab, panel, and button
│   └── ExtCmd.cs                        # Entry point; wires up ViewModel, Events, and Form
│
├── External Event Handlers
│   ├── GenerationExtEventHandler.cs     # Runs slope calculation inside a Revit transaction
│   └── ResetColorsExtEventHandler.cs    # Removes painted faces inside a Revit transaction
│
├── UI
│   ├── Forms/MainForm.cs                # Modeless WinForms view (MetroForm)
│   ├── ViewModels/MainViewModel.cs      # INotifyPropertyChanged ViewModel
│   └── Models/SlopeRange.cs            # Data model for start/end slope range
│
└── Utils
    ├── CalculationUtils.cs              # Geometry traversal and slope computation
    ├── CreateMaterialUtils.cs           # Creates or retrieves named materials by color
    ├── SelectionUtils.cs                # Wraps PickObjects with a floor-only filter
    ├── PaintFacesTracker.cs             # Tracks painted faces for reset support
    └── SelectionFilters/
        └── FloorSelectionFilter.cs      # ISelectionFilter — allows floors only
```

---

## How It Works

1. **Launch** — Click the *Slope Analysis* button under the `KAITECH-BD-R09 → General` ribbon tab.
2. **Select Floors** — Click *Select Floors* and pick the desired floor elements in the viewport.
3. **Define Range** — Enter a start and end slope percentage (e.g., `1` to `5` for 1%–5%).
4. **Run Analysis** — Click *Analysis* to paint floor faces based on slope.
5. **Reset** — Click *Reset* (or close the form) to remove all painted faces.

---

## Slope Calculation

For each face in each floor's geometry, the add-in:

1. Computes the face normal at UV midpoint `(0.5, 0.5)`.
2. Calculates the angle between the normal and the vertical axis (`XYZ.BasisZ`).
3. Converts the angle to a slope percentage: `slope% = tan(angle) × 100`.
4. Paints the face **green** if `startRange ≤ slope% ≤ endRange`, otherwise **red**.

---

## Dependencies

| Package | Version | Purpose |
|---|---|---|
| MetroFramework | 1.2.0.3 | Modern flat UI for WinForms |
| MetroFramework.Design | 1.2.0.3 | Designer support |
| MetroFramework.Fonts | 1.2.0.3 | Custom fonts |
| MetroFramework.RunTime | 1.2.0.3 | Runtime components |
| Autodesk Revit API | — | Revit integration (not a NuGet package) |

Target Framework: **.NET 4.8.1**

---

## Requirements

- Autodesk Revit 2022 or later
- .NET Framework 4.8.1
- The add-in must be registered via a `.addin` manifest file placed in `%APPDATA%\Autodesk\Revit\Addins\<version>\`

---

## Known Limitations

- Painted face data (`PaintFacesTracker`) is stored in memory only. If Revit is restarted without clicking *Reset*, painted faces will remain in the document and cannot be auto-cleared.
- Slope is computed at the face midpoint only; highly irregular faces may not reflect edge conditions.
- Only `OST_Floors` category elements are selectable.
