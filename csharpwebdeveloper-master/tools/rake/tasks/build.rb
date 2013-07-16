require 'albacore'
require 'fileutils'

namespace :build do

  desc "Building - Zoo.AnimalMaker"

  desc "Builds the solution using the supplied config or Debug buildtools by default"
  msbuild :build, [:config] => :ensure_solution_packages  do |msb,args|
    puts "------------- Building - Zoo.AnimalMaker ------------- "
    args.with_defaults(:config => "Debug")
    msb.properties = { :configuration => args[:config]}
    msb.targets = [ :Build ]
    msb.verbosity = :minimal
    msb.parameters = "/maxcpucount"
    msb.solution = "#{SOURCE_ROOT}/#{SOLUTION_NAME}.sln"
  end

  exec :ensure_solution_packages do |cmd|
    cmd.command = "#{NUGET_ROOT}/nuget.exe"
    cmd.parameters = "install #{NUGET_ROOT}/packages.config -o #{SOURCE_ROOT}/packages"
  end

  desc "Cleans the solution"
  msbuild :clean do |msb|
    msb.targets = [:Clean]
    msb.solution = "#{SOURCE_ROOT}/#{SOLUTION_NAME}.sln"
  end
end