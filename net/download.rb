require 'httparty'
 
def download(url)
	#sh 'curl #{url} -o -'
	nugetfile=File.new("NuGet.exe", "wb")
	response = HTTParty.get(url)
	nugetfile.write(response.body)
    nugetfile.close
end

def download_with_progress(url) 
thread = download url
#puts "%.2f%%" % thread[:progress].to_f until thread.join 1
end

def log message
  STDERR.puts message
end