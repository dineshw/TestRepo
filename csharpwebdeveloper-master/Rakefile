require 'fileutils'

FileList['./tools/rake/tasks/*.rb'].each { |f| require f}

#INJECTABLE VARIABLES
CONFIG = ENV['CONFIG'] || 'dev'

SOURCE_ROOT="./src"
SOLUTION_NAME="CSharpWebDeveloper"
NUGET_ROOT="#{SOURCE_ROOT}/.nuget"
NUNIT_CONSOLE_EXE_PATH="#{SOURCE_ROOT}/packages/NUnit.Runners.2.6.2/tools/nunit-console.exe"

task :default do
  #puts "If you need help run rake -T to get a list of all possible tasks."
  puts "Thank you ! - Dinesh W"
end