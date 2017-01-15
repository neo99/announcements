# announcements

# make server listen to IP instead of localhost
```
export ASPNETCORE_URLS="http://192.168.1.144:5000"
```

# setup wireless on Toshiba

check what device is available
```
sudo lshw -C network
```

bring up the disabled wireless (wlp20s0 is the logical name of the device) (ref: https://ubuntuforums.org/showthread.php?t=1490833)
```
sudo ifconfig wlp20s0 up
```

add to start up (ref: http://askubuntu.com/questions/464507/ubuntu-14-04-server-wifi-wpa2-personal)
```
sudo vi /etc/network/interfaces
```

add the following (replace wlan0 with the logical name found above)
```
auto wlan0
iface wlan0 inet dhcp
wpa-ssid <your_router>
wpa-psk <your_wpa_key>
```

