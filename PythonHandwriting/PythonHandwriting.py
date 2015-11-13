import Network as net
import mnist_loader as loader

l = loader.mnist_loader()
labelPath = "train-labels.idx1-ubyte"
imagePath = "train-images.idx3-ubyte"
labels = l.load_data(labelPath,false)
images = l.load_data(imagePath,false)

training_data = (images, labels)

1 + 1