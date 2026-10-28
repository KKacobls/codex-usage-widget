# Codex 額度小工具 — 繁體中文（台灣）

[English](README.md) | [简体中文](README.zh-CN.md) | **繁體中文**

這是原始 [Codex Usage Widget](https://github.com/ognjeeen/codex-usage-widget) 的繁體中文分支。程式會在 Windows 桌面、工作列與系統匣顯示 Codex 額度、下次重置時間及其他使用資訊。這是**第三方開源工具**，不是 OpenAI 官方應用程式。

## 中文化功能

- **Settings → Language → 繁體中文（台灣）**，切換後立即生效。
- Windows 顯示語言是繁體中文（台灣、香港、澳門或 `zh-Hant`）時，可以選擇「跟隨 Windows」。
- 保留原本英文、簡體中文及語言設定儲存功能。
- 額度、重置券、活動狀態、工作列、系統匣及設定等介面皆有繁體中文文字。
- 使用原本的本機 Codex CLI 協定，不改動認證與額度讀取方式。

## Windows 建置

**注意：原作者的 Releases 不包含本分支的繁體中文修改。** 在本分支完成編譯前，不能直接下載原作者版本來使用繁體中文。

Windows 10／11 需安裝 Git 與相容的 .NET 10 SDK：

```powershell
git clone --branch feature/zh-TW https://github.com/KKacobls/codex-usage-widget.git
cd codex-usage-widget
dotnet restore .\CodexUsageWidget.slnx
dotnet build .\CodexUsageWidget.slnx -c Release --no-restore
dotnet test .\CodexUsageWidget.slnx -c Release --no-build
dotnet publish .\src\CodexUsageWidget\CodexUsageWidget.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -p:PublishTrimmed=false -o .\artifacts\zh-TW
```

成功後，可從 `artifacts\zh-TW` 執行 `CodexUsageWidget.exe`。先確認 `codex --version` 可以執行，並透過 `codex login` 登入。

## GitHub Actions 編譯

在你自己的 Fork 中啟用 **Actions**，再執行 `CI` 工作流程並選擇 `feature/zh-TW` 分支。CI 將在 Windows 上建置、測試並上傳 `codex-usage-widget-win-x64` Artifacts。這是工作流程產物，**不是正式發行版**。

更多使用說明請參閱 [英文 README](README.md)。此分支的繁體中文化仍需進行 Windows 視覺排版測試。
