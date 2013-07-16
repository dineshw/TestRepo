require 'albacore'
require 'fileutils'

namespace :test do

  desc "Testing - Zoo.AnimalMaker"

  desc "Run unit tests"
  nunit :all do |nunit|
	puts "------------- Testing - Zoo.AnimalMaker ------------- "
    puts "TEST CONSOLE: #{NUNIT_CONSOLE_EXE_PATH}"
    nunit.command = "#{NUNIT_CONSOLE_EXE_PATH}"
    nunit.assemblies  get_test_dlls.join(" ")
  end

  def get_test_dlls
    test_dlls = []
    (Dir.glob("#{SOURCE_ROOT}/**.*/bin/debug/*Test.dll")).each do |dll|
      test_dlls.push("#{dll}")
    end
    test_dlls
  end

end
