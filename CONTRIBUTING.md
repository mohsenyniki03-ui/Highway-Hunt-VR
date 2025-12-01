# Contributing to Highway-Hunt-VR

Thank you for your interest in contributing to Highway-Hunt-VR! This document provides guidelines for contributing to the project.

## Getting Started

1. Fork the repository
2. Clone your fork locally
3. Create a new branch for your feature or bugfix
4. Make your changes
5. Test your changes in Unity with a VR headset
6. Submit a pull request

## Development Setup

### Prerequisites
- Unity 2022.3 LTS or later
- Git
- Compatible VR headset for testing

### Setting Up the Project
1. Clone the repository
2. Open the project in Unity Hub
3. Install required packages via Package Manager:
   - XR Plugin Management
   - OpenXR Plugin or Oculus XR Plugin
   - XR Interaction Toolkit

## Code Guidelines

### C# Coding Standards
- Follow C# naming conventions
- Use PascalCase for public members
- Use camelCase for private members
- Add XML documentation comments for public APIs
- Keep methods focused and concise

### Unity Best Practices
- Use prefabs for reusable objects
- Organize assets in appropriate folders
- Use ScriptableObjects for configuration data
- Optimize for VR performance (target 72-90 FPS)

## VR-Specific Guidelines

### Performance
- Maintain consistent frame rate for VR comfort
- Avoid sudden camera movements
- Use LOD (Level of Detail) for distant objects
- Optimize draw calls and batching

### Comfort
- Provide comfort options for motion sensitivity
- Avoid rapid acceleration or rotation
- Test with multiple users for motion sickness feedback

## Submitting Changes

### Pull Request Process
1. Update documentation if needed
2. Test your changes on VR hardware
3. Describe your changes clearly in the PR description
4. Link any related issues

### Commit Messages
- Use clear, descriptive commit messages
- Start with a verb (Add, Fix, Update, Remove)
- Keep the first line under 50 characters

## Questions?

If you have questions, feel free to open an issue for discussion.
