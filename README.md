    # This is a basic workflow to help you get started with Actions
    # Controls when the action will run. Triggers the workflow on push or pull request 
    # events but only for the master branch
    # A workflow run is made up of one or more jobs that can run sequentially or in parallel
    # This workflow contains a single job called "build"
    # The type of runner that the job will run on
    # Steps represent a sequence of tasks that will be executed as part of the job    
    # Checks-out your repository under $GITHUB_WORKSPACE, so your job can access it


name: CI

on:

  push:
  
    branches: [ master ]
    
  pull_request:
  
    branches: [ master ]
    
jobs:

  build:
  
    runs-on: [windows-latest]
    steps:
    - uses: actions/checkout@v2
    - name: Setup MSBuild
    
      uses: microsoft/setup-msbuild@v1
    - name: Setup NuGet
    
      uses: NuGet/setup-nuget@v1.0.5      
    - name: Restore NuGet packages
    
      run: nuget restore MyOnionApi1/MyOnionApi1.sln
    - name: Build the Solution
      run: msbuild MyOnionApi1/MyOnionApi1.sln /p:Configuration=Release
