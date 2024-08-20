EventBus Example

Channels are converted to SO and in addition EventBus is converted to MonoBehaviour. But it is meaningless. It can be remain SO. Right now EventBus class is singleton. When this class convert again to SO then it will not be singleton. Because sometimes multiple EventBuses may be necceseary.
