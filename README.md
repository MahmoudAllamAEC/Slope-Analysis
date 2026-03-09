# 📐 Slope Analysis — Revit Add-in

<div align="center">

[![Revit API](https://img.shields.io/badge/Revit%20API-2022%2B-blue?style=for-the-badge&logo=autodesk)](https://www.autodesk.com/developer-network/platform-technologies/revit)
[![Language](https://img.shields.io/badge/C%23-.NET%204.8.1-purple?style=for-the-badge&logo=csharp)](https://dotnet.microsoft.com/)
[![Pattern](https://img.shields.io/badge/Pattern-MVVM-orange?style=for-the-badge)]()
[![License](https://img.shields.io/badge/License-MIT-yellow?style=for-the-badge)]()

**A Revit plugin that visually paints floor faces green or red based on whether their slope falls within a user-defined range — turning a manual, error-prone calculation into an instant one-click analysis.**

[▶️ Watch Demo Video](https://drive.google.com/file/d/1tnj4oVCfFXq43UIVp_FUuqnMGukKSceQ/view?usp=sharing) • [📥 Download Installer](https://github.com/MahmoudAllamAEC/Slope-Analysis/releases/tag/BimDev)

</div>

---

## 🎬 Demo

[![Watch Demo](https://img.shields.io/badge/▶_Watch_Full_Demo-Google_Drive-red?style=for-the-badge&logo=google-drive)](https://drive.google.com/file/d/1tnj4oVCfFXq43UIVp_FUuqnMGukKSceQ/view?usp=sharing)

<!-- 💡 TO DO: Add a screenshot here showing colored floor faces in Revit -->
<!-- ![Slope Analysis in action](docs/screenshots/slope-preview.png) -->

---

## 🧩 What Problem Does It Solve?

In drainage design, accessibility compliance, and waterproofing — floor slope is critical. Verifying it manually means:
- Checking each floor element individually in Revit properties
- Manually calculating slope percentages from geometry
- No visual feedback on which floors pass or fail

**Slope Analysis eliminates this.** Define your acceptable slope range, select your floors, and the plugin instantly paints every face — green if it passes, red if it fails — directly in your 3D view.

---

## ✨ Features

| Feature | Description |
|---|---|
| 🖱️ **Floor Selection** | Pick one or more floor elements directly in the Revit viewport |
| 📏 **Slope Range Input** | Define a min and max slope percentage to evaluate |
| 🎨 **Face Painting** | Paints each floor face green (in range) or red (out of range) |
| ↩️ **Reset** | Removes all applied paint and restores original appearance |
| 🪟 **Modern UI** | Built with MetroFramework for a clean, flat Windows Forms interface |
| ⚙️ **Auto Installer** | One-click Inno Setup installer for Revit 2022+ |

---

## 🖥️ Screenshots

<div align="center">

<!-- 💡 TO DO: Upload screenshots to docs/screenshots/ and update paths below -->

| Plugin UI | Green / Red Face Painting |
|---|---|
| ![UI](https://github.com/MahmoudAllamAEC/Slope-Analysis/blob/master/Snipaste_2026-03-10_11-28-41.png) | ![Painting](https://github.com/MahmoudAllamAEC/Slope-Analysis/blob/master/Snipaste_2026-03-10_11-29-41.png) | 

</div>

---

## 🏗️ Architecture

This plugin follows the **MVVM pattern** with Revit's **External Event** mechanism — the correct approach for modeless forms that need to safely interact with the Revit document without blocking the UI thread.

```
├── Revit Entry
│   ├── ExtApp.cs                        # Registers ribbon tab, panel, and button
│   └── ExtCmd.cs                        # Entry point; wires ViewModel, Events, and Form
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
    ├── CreateMaterialUtils.cs           # Creates/retrieves named materials by color
    ├── SelectionUtils.cs                # Wraps PickObjects with floor-only filter
    ├── PaintFacesTracker.cs             # Tracks painted faces for reset support
    └── SelectionFilters/
        └── FloorSelectionFilter.cs      # ISelectionFilter — allows floors only
```

---

## 📐 How the Slope Calculation Works

For each face in each selected floor's geometry, the plugin:

1. Computes the **face normal** at UV midpoint `(0.5, 0.5)`
2. Calculates the **angle** between the normal and the vertical axis (`XYZ.BasisZ`)
3. Converts to a **slope percentage**: `slope% = tan(angle) × 100`
4. Paints the face **🟢 green** if `startRange ≤ slope% ≤ endRange`, otherwise **🔴 red**

---

## 🚀 How to Use

1. Open any Revit project with floor elements
2. Go to **KAITECH-BD-R09 tab → General → Slope Analysis**
3. Click **Select Floors** and pick floors in the viewport
4. Enter your **Start** and **End** slope percentage (e.g. `1` to `5` for 1%–5%)
5. Click **Analysis** — floors are instantly painted based on slope
6. Click **Reset** to remove all painted faces

---

## 📦 Installation

### Option 1 — Installer (Recommended)

1. Download from the [Releases page](https://github.com/MahmoudAllamAEC/Slope-Analysis/releases/tag/BimDev)
2. Run the Inno Setup installer
3. Launch Revit → **KAITECH-BD-R09** tab → **Slope Analysis**

### Option 2 — Manual

1. Clone this repository and build in Visual Studio
2. Copy the `.addin` manifest and `.dll` to:
   ```
   %APPDATA%\Autodesk\Revit\Addins\{RevitVersion}\
   ```

---

## 📦 Dependencies

| Package | Version | Purpose |
|---|---|---|
| MetroFramework | 1.2.0.3 | Modern flat UI for WinForms |
| MetroFramework.Design | 1.2.0.3 | Designer support |
| MetroFramework.Fonts | 1.2.0.3 | Custom fonts |
| MetroFramework.RunTime | 1.2.0.3 | Runtime components |
| Autodesk Revit API | — | Revit integration |

**Target Framework:** .NET 4.8.1

---

## ⚠️ Known Limitations

- Painted face data is stored **in memory only**. If Revit is restarted without clicking Reset, painted faces remain in the document and cannot be auto-cleared on next launch.
- Slope is computed at the **face midpoint** only — highly irregular faces may not reflect edge conditions accurately.
- Only `OST_Floors` category elements are selectable.

---

## 🗺️ Roadmap

- [ ] WPF UI redesign (full MVVM, replace MetroFramework)
- [ ] Support for Ramps, Roofs, and Topography elements
- [ ] Persistent face data (save/load with Extensible Storage)
- [ ] Export slope report to Excel / PDF
- [ ] Custom color gradient for slope intensity visualization

---

## 👤 Author

**Mahmoud Amr Allam**  
Architect & BIM Software Developer

[![LinkedIn](https://img.shields.io/badge/LinkedIn-Connect-blue?style=flat-square&logo=linkedin)](https://www.linkedin.com/in/mahmoud-allam-4a25b4172/)
[![Email](https://img.shields.io/badge/Email-mahmoud.amr55@gmail.com-red?style=flat-square&logo=gmail)](mailto:mahmoud.amr55@gmail.com)
[![GitHub](https://img.shields.io/badge/GitHub-MahmoudAllamAEC-black?style=flat-square&logo=github)](https://github.com/MahmoudAllamAEC)

---

<div align="center">

⭐ **If this project helped you, please give it a star!** ⭐

</div>
