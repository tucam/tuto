package e4geotools.handlers;

import javax.inject.Inject;

import org.eclipse.e4.core.di.annotations.Execute;
import org.eclipse.e4.core.services.events.IEventBroker;
import org.eclipse.e4.ui.model.application.ui.basic.MPart;

public class ZoomInMapHandler {
	@Inject
	private IEventBroker eventBroker;

	@Execute
	public void zoomIn(MPart part) {
		eventBroker.send("e4geotools/zoomInMapEventTopic", part);
	}
}
