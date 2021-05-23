Jak to vsechno funguje?




Uz hotovej exporter
- mozna pouzit jeho ?
https://github.com/s-d-a/DCS-ExportScripts

- simple export server
https://github.com/Dirt-e/DCS-Export-Server-Simple








==================





There is no single document that will teach you everything you need to know about Export.lua. You will have to piece together information from several sources and do some trial and error.



Start with the developer blog post that introduced Export.lua (it is no longer online, but the Internet Archive has you covered):

https://web.archive.org/web/20141130081345/http://www.digitalcombatsimulator.com/en/dev_journal/lua-export/



To learn the Lua programming language (DCS uses version 5.1):

https://www.lua.org/manual/5.1/



To make trial and error easier, you can use the Lua Console in my "DCS Witchcraft" project (link in my sig). Open the comments in the "WitchcraftExport.lua" file to set it up for the Export.lua environment.



To manipulate controls and get data out of the sim, you will need to understand how a clickable cockpit works internally. To learn more about the concepts of device IDs, command IDs, and argument numbers, refer to the Beginners Guide to DCS World Aircraft Mods (chapter 10 IIRC).



To find out which argument numbers, device IDs, and command IDs your aircraft uses, look at the files under "mods/aircraft/YOUR_ACFT/Cockpit/Scripts", especially "clickabledata.lua", "mainpanel_init.lua" and "devices.lua".



To visually understand cockpit arguments, use the ED Model Viewer. It allows you to load a cockpit model and manipulate cockpit arguments to see their effect on the model.



To see how it all fits together, it helps to read other people's Export.lua files, for example the ones from Helios or DCS-BIOS.



Finally, here's a very quick guide to clickable cockpits as I understand it:

   A device is a controller that handles a certain subsystem, such as the ILS or the Altimeter. Each device is identified by a device ID. You can get the device object from Export.lua with the "GetDevice" function.
   You can send commands to a device by using the "performClickableAction" method of the device object. It expects two parameters. The first one is a command, which is usually looks like "device_commands.Button1" in clickabledata.lua. That translates to 3000 + button number. The second one is an "argument". Exactly how that second parameter is interpreted depends on which switch we are talking about, but often it corresponds to a cockpit argument value.
   Most gauges and instruments are attached directly to the 3D cockpit model. Every moving element (for example, a gauge needle) has an animation attached to it in 3DS Max. A "cockpit argument" (which is a floating point number somewhere between -1 and 1) controls which frame of the animation is shown. Cockpit arguments are numbered. For example, cockpit argument 404 in the A-10C controls the Master Caution indicator light. If its value is 0, the light is off, if its value is 1, the light is on.
   You can get the value of a cockpit argument from Export.lua with "GetDevice(0):get_argument_value(number)".
   Some displays in the cockpit are drawn to seperate textures and then plastered onto the cockpit wall. They can be exported to another monitor by editing some Lua files and using MonitorSetup.lua. For some of those displays, the list_indication function can be used to get their text contents.



If you tell me what you want to accomplish with Export.lua, I may be able to provide some more specific advice.
