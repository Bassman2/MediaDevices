# Copilot Instructions

## Project Guidelines
- When modifying StreamWrapper, make the COM `stream` field nullable and only set it to null in Dispose; avoid using `Marshal.GetIUnknownForObject` or relying on the wrapper implementing IDisposable because COM interop may be disabled.